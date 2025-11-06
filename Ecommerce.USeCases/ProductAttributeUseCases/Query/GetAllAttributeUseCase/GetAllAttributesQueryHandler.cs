namespace Ecommerce.UseCases.ProductAttributeUseCases.Query.GetAllAttributeUseCase;

public class GetAllAttributesQueryHandler : IRequestHandler<GetAllAttributesQuery, IReadOnlyList<ProductAttributeToReturnDto>?>
{
    private readonly IProductAttributeService _attributeService;

    public GetAllAttributesQueryHandler(IProductAttributeService attributeService)
     => _attributeService = attributeService;
    public async Task<IReadOnlyList<ProductAttributeToReturnDto>?> Handle(GetAllAttributesQuery request, CancellationToken cancellationToken)
     => await _attributeService.GetAllAttributesAsync(cancellationToken);
}