
namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.DeleteProductAttributeUseCase;

public class DeleteProductAttributeCommandHandler : IRequestHandler<DeleteProductAttributeCommand, bool>
{
    private readonly IProductAttributeService _attributeService;

    public DeleteProductAttributeCommandHandler(IProductAttributeService attributeService)
        => _attributeService = attributeService;
    public async Task<bool> Handle(DeleteProductAttributeCommand request, CancellationToken cancellationToken)
        => await _attributeService.DeleteAttributeAsync(request.attId, cancellationToken);
}
