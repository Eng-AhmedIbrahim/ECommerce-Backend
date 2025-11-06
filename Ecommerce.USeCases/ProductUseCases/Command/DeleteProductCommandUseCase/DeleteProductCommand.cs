namespace Ecommerce.UseCases.ProductUseCases.Command.DeleteProductCommandUseCase;

public record DeleteProductCommand(int productId) : IRequest<bool>{}