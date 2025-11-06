namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.DeleteProductAttributeUseCase;

public record DeleteProductAttributeCommand(int attId) : IRequest<bool> { }
