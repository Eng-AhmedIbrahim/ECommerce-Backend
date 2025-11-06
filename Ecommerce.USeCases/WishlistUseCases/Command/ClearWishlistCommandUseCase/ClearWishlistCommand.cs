namespace Ecommerce.UseCases.WishlistUseCases.Command.ClearWishlistCommandUseCase;

public record ClearWishlistCommand(string UserId) : IRequest<WishlistResult>
{
}