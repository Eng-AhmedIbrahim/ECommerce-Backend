namespace Ecommerce.UseCases.WishlistUseCases.Command.RemoveItemFromWishlistCommandUseCase;

public class RemoveItemFromWishlistCommandHandler : IRequestHandler<RemoveItemFromWishlistCommand, WishlistResult>
{
    private readonly IWishlistService _wishlistService;

    public RemoveItemFromWishlistCommandHandler(IWishlistService wishlistService)
     => _wishlistService = wishlistService;
    public async Task<WishlistResult> Handle(RemoveItemFromWishlistCommand request, CancellationToken cancellationToken)
        => await _wishlistService.RemoveItemFromWishlistAsync(request.UserId, request.ProductId, cancellationToken);
}
