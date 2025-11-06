namespace Ecommerce.Infrastructure.Services.WishlistServices;

public partial class WishlistService
{
    public async Task<WishlistResult> AddItemToWishlistAsync(string userId, int productId, CancellationToken cancellationToken)
    {
        try
        {
            var wishlistSpecs = new GetWishlistByUserIdAndProductIdSpecs(userId, productId);
            var context = _unitOfWork.Repository<Wishlist>();

            var existItem = await context.GetByIdWithSpecsWithTrackingAsync(wishlistSpecs, cancellationToken);

            if (existItem is not null)
                return WishlistResult.AlreadyExists;

            var wishlistItem = new Wishlist
            {
                UserId = userId,
                ProductId = productId,
            };

            await context.AddAsync(wishlistItem, cancellationToken);

            var saveResult = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

            return saveResult
                ? WishlistResult.Added
                : WishlistResult.Failed;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error adding item {ProductId} to wishlist for user {UserId}", productId, userId);
            return WishlistResult.Failed;
        }
    }
}