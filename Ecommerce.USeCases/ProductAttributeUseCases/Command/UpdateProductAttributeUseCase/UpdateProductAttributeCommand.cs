namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.UpdateProductAttributeUseCase;

public record UpdateProductAttributeCommand
    (
        int attId,
        ProductAttributeDto attributeDto
    ) : IRequest<ProductAttributeToReturnDto>
{ }