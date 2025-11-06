namespace Ecommerce.UseCases.WishlistUseCases.Command.AddItemToWishlistCommandUseCase;

public record AddItemToWishlistCommand
    (
    string UserId,
    int ProductId
) : IRequest<WishlistResult>;
