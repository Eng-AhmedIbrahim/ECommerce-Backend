namespace Ecommerce.UseCases.WishlistUseCases.Command.AddItemToWishlistCommandUseCase;

public class AddItemToWishlistCommandHandler : IRequestHandler<AddItemToWishlistCommand, WishlistResult>
{
    private readonly IWishlistService _wishlistService;

    public AddItemToWishlistCommandHandler(IWishlistService wishlistService)
     =>   _wishlistService = wishlistService;
    
    public async Task<WishlistResult> Handle(AddItemToWishlistCommand request, CancellationToken cancellationToken)
     =>   await _wishlistService.AddItemToWishlistAsync(request.UserId, request.ProductId, cancellationToken);
}