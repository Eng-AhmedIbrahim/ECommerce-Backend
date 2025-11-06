namespace Ecommerce.UseCases.ProductAttributeUseCases.Query.GetAttributeByIdUseCase;

public record GetAttributeByIdQuery(int attributeId) : IRequest<ProductAttributeToReturnDto?>
{
}
