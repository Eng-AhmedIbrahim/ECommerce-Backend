namespace Ecommerce.UseCases.ProductAttributeUseCases.Query.GetAttributeByIdUseCase;

public class GetAttributeByIdQueryHandler : IRequestHandler<GetAttributeByIdQuery, ProductAttributeToReturnDto?>
{
    private readonly IProductAttributeService _attributeService;
    public GetAttributeByIdQueryHandler(IProductAttributeService attributeService)
     => _attributeService = attributeService;
    public async Task<ProductAttributeToReturnDto?> Handle(GetAttributeByIdQuery request, CancellationToken cancellationToken)
     => await _attributeService.GetAttributeByIdAsync(request.attributeId, cancellationToken);
}