namespace Ecommerce.UseCases.ProductUseCases.Command.CreateProductCommandUseCase;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductToReturnDto?>
{
    private readonly IProductService _productService;

    public CreateProductCommandHandler(IProductService productService)
     => _productService = productService;
    public async Task<ProductToReturnDto?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        => await _productService.CreateProductAsync(request.ProductDto, cancellationToken);
}
