namespace Ecommerce.Infrastructure.Services.WishlistServices;

public partial class WishlistService
{
    public async Task<WishlistResult> ClearWishlistAsync(string userId, CancellationToken cancellationToken)
    {
        try
        {
            var context = _unitOfWork.Repository<Wishlist>();
            var wishlistSpecs = new GetWishlistByUserIdSpecs(userId);

            var wishList = await context.GetAllWithSpecsAsNoTrackingAsync(wishlistSpecs, cancellationToken);

            if (wishList is null || !wishList.Any())
                return WishlistResult.NotFound;

            await context.ExecuteDeleteAsync(w => w.UserId == userId, cancellationToken);

            return WishlistResult.Deleted;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error clearing wishlist for user {UserId}", userId);
            return WishlistResult.Failed;
        }
    }

    public async Task<WishlistResult> RemoveItemFromWishlistAsync(string userId, int productId, CancellationToken cancellationToken)
    {
        try
        {
            var context = _unitOfWork.Repository<Wishlist>();
            var wishlistSpecs = new GetWishlistByUserIdAndProductIdSpecs(userId, productId);

            var existingItem = await context.GetByIdWithSpecsWithTrackingAsync(wishlistSpecs, cancellationToken);

            if (existingItem is null)
                return WishlistResult.NotFound;

            await context.ExecuteDeleteAsync(
                w => w.UserId == userId && w.ProductId == productId,
                cancellationToken
            );

            return WishlistResult.Deleted;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error removing item {ProductId} from wishlist for user {UserId}", productId, userId);
            return WishlistResult.Failed;
        }
    }
}