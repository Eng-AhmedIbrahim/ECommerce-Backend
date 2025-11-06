namespace Ecommerce.UseCases.ProductUseCases.Command.UpdateProductCommandUseCase.UpdatedProductCommandValidation;

public class UpdateProductCommandValidator :AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.productId)
            .GreaterThan(0).WithMessage("ProductId must be valid.");

        RuleFor(c => c.UpdatedProductDto)
            .NotNull().WithMessage("Updated product data is required.")
            .SetValidator(new UpdatedProductDtoValidator());
    }
}
