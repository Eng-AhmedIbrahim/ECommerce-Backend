namespace Ecommerce.UseCases.ProductUseCases.Query.GetProductByIdUseCase;

public record GetProductByIdQuery(int ProductId) : IRequest<ProductToReturnDto?> { }
