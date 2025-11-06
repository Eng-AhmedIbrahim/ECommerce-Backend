namespace Ecommerce.Infrastructure.Services.WishlistServices;

public partial class WishlistService
{
    public async Task<ICollection<int>?> GetWishListItemsAsync(
        string userId,
        CancellationToken cancellationToken)
    {
        try
        {
            var context = _unitOfWork.Repository<Wishlist>();
            var wishlistSpecs = new GetWishlistByUserIdSpecs(userId);

            var wishlistItems = await context.GetAllWithSpecsAsNoTrackingAsync(
                wishlistSpecs,
                cancellationToken
            );

            if (wishlistItems is null || !wishlistItems.Any())
                return Array.Empty<int>();

            return wishlistItems.Select(w => w.ProductId).ToList();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error retrieving wishlist for user {UserId}", userId);
            return Array.Empty<int>(); 
        }
    }
}