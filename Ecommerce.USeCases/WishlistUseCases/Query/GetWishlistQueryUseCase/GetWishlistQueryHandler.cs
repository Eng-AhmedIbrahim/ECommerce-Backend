namespace Ecommerce.UseCases.WishlistUseCases.Query.GetWishlistQueryUseCase;

public class GetWishlistQueryHandler : IRequestHandler<GetWishlistQuery, ICollection<int>?>
{
    private readonly IWishlistService _wishlistService;

    public GetWishlistQueryHandler(IWishlistService wishlistService)
     => _wishlistService = wishlistService;
    public async Task<ICollection<int>?> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
        => await _wishlistService.GetWishListItemsAsync(request.UserId!, cancellationToken);
}