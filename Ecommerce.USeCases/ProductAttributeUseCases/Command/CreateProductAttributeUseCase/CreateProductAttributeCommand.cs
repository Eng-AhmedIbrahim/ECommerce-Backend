namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.CreateProductAttributeUseCase;

public record CreateProductAttributeCommand(
    ProductAttributeDto AttributeDto) : IRequest<ProductAttributeToReturnDto?>{}
