namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.DeleteProductAttributeUseCase;

public class DeleteProductAttributeCommandValidator :AbstractValidator<DeleteProductAttributeCommand>
{
    public DeleteProductAttributeCommandValidator()
    {
        RuleFor(RuleFor => RuleFor.attId)
            .GreaterThan(0)
            .WithMessage("Attribute Id must be greater than zero");
    }
}
