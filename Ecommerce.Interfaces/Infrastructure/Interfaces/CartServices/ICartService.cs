namespace Ecommerce.Interfaces.Infrastructure.Interfaces.CartServices;

public interface ICartService
{
    Task<UserCart?> GetCartAsync(string? userId
        , CancellationToken cancellationToken);

    Task<UserCart> AddToCartAsync(string? userId, CartItem item
        , CancellationToken cancellationToken);

    Task<UserCart> UpdateCartItemAsync(string? userId, CartItem updatedItem
        , CancellationToken cancellationToken);

    Task<UserCart> RemoveCartItemAsync(string? userId, int productId
        , CancellationToken cancellationToken);

    Task<UserCart> ClearCartAsync(string? userId
        , CancellationToken cancellationToken);
}