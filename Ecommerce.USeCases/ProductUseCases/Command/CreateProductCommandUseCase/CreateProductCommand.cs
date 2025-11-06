namespace Ecommerce.UseCases.ProductUseCases.Command.CreateProductCommandUseCase;

public record CreateProductCommand(ProductDto ProductDto) : IRequest<ProductToReturnDto> { }