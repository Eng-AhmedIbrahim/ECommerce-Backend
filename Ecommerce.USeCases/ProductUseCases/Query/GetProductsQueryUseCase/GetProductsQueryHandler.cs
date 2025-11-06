namespace Ecommerce.UseCases.ProductUseCases.Query.GetProductsQueryUseCase;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ICollection<ProductToReturnDto>?>
{
    private readonly IProductService _productService;

    public GetProductsQueryHandler(IProductService productService)
     => _productService = productService;

    public async Task<ICollection<ProductToReturnDto>?> Handle(GetProductsQuery request, 
        CancellationToken cancellationToken)
     => await _productService.GetProductsAsync(request.productSpecs,cancellationToken);
}