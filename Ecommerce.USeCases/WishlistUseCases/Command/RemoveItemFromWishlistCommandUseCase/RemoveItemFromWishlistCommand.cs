namespace Ecommerce.UseCases.WishlistUseCases.Command.RemoveItemFromWishlistCommandUseCase;

public record RemoveItemFromWishlistCommand
    (
    string UserId,
    int ProductId
    ) : IRequest<WishlistResult>;