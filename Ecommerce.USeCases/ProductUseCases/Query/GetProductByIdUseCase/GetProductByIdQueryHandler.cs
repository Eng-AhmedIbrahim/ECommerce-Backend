namespace Ecommerce.UseCases.ProductUseCases.Query.GetProductByIdUseCase;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductToReturnDto?>
{
    private readonly IProductService _productService;

    public GetProductByIdQueryHandler(IProductService productService)
     => _productService = productService;

    public Task<ProductToReturnDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        => _productService.GetProductByIdAsync(request.ProductId, cancellationToken);
}