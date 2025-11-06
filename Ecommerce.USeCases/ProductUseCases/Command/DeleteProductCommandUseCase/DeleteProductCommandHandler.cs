namespace Ecommerce.UseCases.ProductUseCases.Command.DeleteProductCommandUseCase;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductService _productService;
    public DeleteProductCommandHandler(IProductService productService)
       => _productService = productService;
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
      => await _productService.DeleteProductAsync(request.productId, cancellationToken);
}