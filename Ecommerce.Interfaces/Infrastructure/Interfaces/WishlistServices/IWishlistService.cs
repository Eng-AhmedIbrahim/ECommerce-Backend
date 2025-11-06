namespace Ecommerce.Interfaces.Infrastructure.Interfaces.WishlistServices;

public interface IWishlistService
{
    public Task<WishlistResult> AddItemToWishlistAsync(string userId, int productId,CancellationToken cancellationToken);
    public Task<WishlistResult> RemoveItemFromWishlistAsync(string userId, int productId, CancellationToken cancellationToken);
    public Task<ICollection<int>?> GetWishListItemsAsync(string userId, CancellationToken cancellationToken);
    public Task<WishlistResult> ClearWishlistAsync(string userId, CancellationToken cancellationToken);
}