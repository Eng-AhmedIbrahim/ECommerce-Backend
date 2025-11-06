namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.CreateProductAttributeUseCase;

public class CreateProductAttributeCommandHandler : IRequestHandler<CreateProductAttributeCommand, ProductAttributeToReturnDto?>
{
    private readonly IProductAttributeService _attributeService;

    public CreateProductAttributeCommandHandler(IProductAttributeService attributeService)
        => _attributeService = attributeService;

    public async Task<ProductAttributeToReturnDto?> Handle(CreateProductAttributeCommand request, CancellationToken cancellationToken)
        => await _attributeService.CreateAttributeAsync(request.AttributeDto, cancellationToken);
}