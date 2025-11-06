namespace Ecommerce.UseCases.WishlistUseCases.Query.GetWishlistQueryUseCase;

public record GetWishlistQuery(string? UserId) : IRequest<ICollection<int>?>
{ }