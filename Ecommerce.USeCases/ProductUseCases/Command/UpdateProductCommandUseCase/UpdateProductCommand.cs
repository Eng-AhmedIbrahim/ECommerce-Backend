namespace Ecommerce.UseCases.ProductUseCases.Command.UpdateProductCommandUseCase;

public record UpdateProductCommand
    (
    int productId,
    UpdatedProductDto UpdatedProductDto) : IRequest<ProductToReturnDto?>
{ }