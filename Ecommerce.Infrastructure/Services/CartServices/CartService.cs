namespace Ecommerce.Infrastructure.Services.CartServices;

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;

    public CartService(IUnitOfWork unitOfWork)
     => _unitOfWork = unitOfWork;

    public async Task<UserCart?> GetCartAsync(string? userId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentNullException(nameof(userId), "User ID cannot be null or empty");

        try
        {
            var cartRepo = _unitOfWork.Repository<UserCart>();
            var spec = new CartSpecificationsWithFilter(userId);
            var cart = await cartRepo.GetByIdWithSpecsAsNotTrackingAsync(spec, cancellationToken);

            if (cart is null)
            {
                cart = new UserCart
                {
                    UserId = userId,
                    Items = new List<CartItem>(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await cartRepo.AddAsync(cart, cancellationToken);
                await _unitOfWork.CompleteAsync(cancellationToken);

                Log.Information("Created new cart for user {UserId}", userId);
            }

            return cart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error in GetCartAsync for user {UserId}", userId);
            throw;
        }
    }

    public async Task<UserCart> AddToCartAsync(string? userId, CartItem item, CancellationToken cancellationToken)
    {
        if (userId == null) throw new ArgumentNullException(nameof(userId));

        var cart = await GetCartAsync(userId, cancellationToken);

        var existingItem = cart!.Items.FirstOrDefault(i =>
            i.ProductId == item.ProductId &&
            CompareVariants(i.SelectedVariants, item.SelectedVariants)
        );

        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
            existingItem.Price = item.Price;
        }
        else
        {
            var cleanVariants = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(
                JsonConvert.SerializeObject(item.SelectedVariants, new JsonSerializerSettings
                {
                    StringEscapeHandling = StringEscapeHandling.Default
                })
            );

            item.SelectedVariants = cleanVariants ?? new Dictionary<string, List<string>>();

            cart.Items.Add(item);
        }

        CalculateTotals(cart);

        await _unitOfWork.Repository<UserCart>().UpdateAsync(cart);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return cart;
    }



    public async Task<UserCart> UpdateCartItemAsync(string? userId, CartItem updatedItem, CancellationToken cancellationToken)
    {
        try
        {
            var cart = await GetCartAsync(userId);

            var existingItem = cart?.Items.FirstOrDefault(i =>
                i.Id == updatedItem.Id );

            if (existingItem == null)
                return cart ?? new();


            existingItem.Quantity = updatedItem.Quantity;
            existingItem.Price = updatedItem.Price;

            CalculateTotals(cart!);
            await _unitOfWork.Repository<UserCart>().UpdateAsync(cart!);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return cart!;
        }
        catch (Exception ex)
        {
            Log.Error("Error in UpdateCartItemAsync: {Message}", ex.Message);
            throw;
        }
    }

    public async Task<UserCart> RemoveCartItemAsync(string? userId, int productId, CancellationToken cancellationToken)
    {
        try
        {
            UserCart? cart = await GetCartAsync(userId);
            var item = cart?.Items.FirstOrDefault(i => i.Id == productId);

            if (item != null)
            {
                var cartItemRepo = _unitOfWork.Repository<CartItem>();
                await cartItemRepo.DeleteAsync(item);
                cart?.Items.Remove(item);
            }

            CalculateTotals(cart ?? new());
            await _unitOfWork.Repository<UserCart>().UpdateAsync(cart!);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return cart!;
        }
        catch (Exception ex)
        {
            Log.Error("Error in RemoveCartItemAsync: {Message}", ex.Message);
            throw;
        }
    }

    public async Task<UserCart> ClearCartAsync(string? userId, CancellationToken cancellationToken)
    {
        try
        {
            var cart = await GetCartAsync(userId);

            cart!.Items.Clear();
            CalculateTotals(cart);

            await _unitOfWork.Repository<UserCart>().UpdateAsync(cart);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return cart;
        }
        catch (Exception ex)
        {
            Log.Error("Error in ClearCartAsync: {Message}", ex.Message);
            throw;
        }
    }
    private bool CompareVariants(Dictionary<string, List<string>>? v1, Dictionary<string, List<string>>? v2)
    {
        if (v1 == null && v2 == null) return true;
        if (v1 == null || v2 == null) return false;
        if (v1.Count != v2.Count) return false;

        foreach (var key in v1.Keys)
        {
            if (!v2.ContainsKey(key)) return false;
            if (!v1[key].SequenceEqual(v2[key], StringComparer.Ordinal)) return false;
        }

        return true;
    }

    private void CalculateTotals(UserCart cart)
    {
        cart.TotalItems = cart.Items.Count;
        cart.TotalQuantity = cart.Items.Sum(i => i.Quantity);
        cart.SubTotal = cart.Items.Sum(i => i.Price * i.Quantity);
        cart.GrandTotal = cart.SubTotal - (cart.DiscountTotal ?? 0);
        cart.UpdatedAt = DateTime.UtcNow;
    }
}