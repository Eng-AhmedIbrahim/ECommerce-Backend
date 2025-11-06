namespace Ecommerce.UseCases.ProductUseCases.Command.DeleteProductCommandUseCase;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.productId)
            .GreaterThan(0)
            .WithMessage("Product ID must be greater than zero.");
    }
}