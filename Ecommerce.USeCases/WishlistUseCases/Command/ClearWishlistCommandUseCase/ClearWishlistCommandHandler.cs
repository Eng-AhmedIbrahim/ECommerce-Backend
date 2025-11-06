namespace Ecommerce.UseCases.WishlistUseCases.Command.ClearWishlistCommandUseCase;

public class ClearWishlistCommandHandler : IRequestHandler<ClearWishlistCommand, WishlistResult>
{
    private readonly IWishlistService _wishlistService;
    public ClearWishlistCommandHandler(IWishlistService wishlistService)
     => _wishlistService = wishlistService;
    public async Task<WishlistResult> Handle(ClearWishlistCommand request, CancellationToken cancellationToken)
        => await _wishlistService.ClearWishlistAsync(request.UserId, cancellationToken);
}