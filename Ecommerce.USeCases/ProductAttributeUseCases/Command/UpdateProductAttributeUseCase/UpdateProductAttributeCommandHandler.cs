namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.UpdateProductAttributeUseCase;

public class UpdateProductAttributeCommandHandler : IRequestHandler<UpdateProductAttributeCommand, ProductAttributeToReturnDto?>
{
    private readonly IProductAttributeService _attributeService;
    public UpdateProductAttributeCommandHandler(IProductAttributeService attributeService)
        => _attributeService = attributeService;
    public async Task<ProductAttributeToReturnDto?> Handle(UpdateProductAttributeCommand request, CancellationToken cancellationToken)
        => await _attributeService.UpdateAttributeAsync(request.attId, request.attributeDto, cancellationToken);
}