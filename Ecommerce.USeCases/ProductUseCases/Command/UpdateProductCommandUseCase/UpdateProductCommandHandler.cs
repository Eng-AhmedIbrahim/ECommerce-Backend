namespace Ecommerce.UseCases.ProductUseCases.Command.UpdateProductCommandUseCase;

public class UpdateProductCommandHandler  : IRequestHandler<UpdateProductCommand, ProductToReturnDto?>
{
    private readonly IProductService _productService;
    public UpdateProductCommandHandler(IProductService productService)
       => _productService = productService;
    public async Task<ProductToReturnDto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
       => await _productService.UpdateProductAsync(request.productId, request.UpdatedProductDto, cancellationToken);
}