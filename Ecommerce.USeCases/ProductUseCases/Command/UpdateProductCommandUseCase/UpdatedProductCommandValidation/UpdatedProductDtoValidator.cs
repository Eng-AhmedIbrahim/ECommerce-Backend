namespace Ecommerce.UseCases.ProductUseCases.Command.UpdateProductCommandUseCase.UpdatedProductCommandValidation;

public class UpdatedProductDtoValidator : AbstractValidator<UpdatedProductDto>
{
    public UpdatedProductDtoValidator()
    {
        RuleFor(p => p.ArabicName)
            .NotEmpty().WithMessage("Arabic name is required.")
            .MaximumLength(Constants.NameLength)
            .WithMessage($"Arabic name cannot exceed {Constants.NameLength} characters.");

        RuleFor(p => p.EnglishName)
            .NotEmpty().WithMessage("English name is required.")
            .MaximumLength(Constants.NameLength)
            .WithMessage($"English name cannot exceed {Constants.NameLength} characters.");

        RuleFor(p => p.ArabicDescription)
            .NotEmpty().WithMessage("Arabic description is required.")
            .MaximumLength(Constants.MaxDescriptionLength)
            .WithMessage($"Arabic description cannot exceed {Constants.MaxDescriptionLength} characters.");

        RuleFor(p => p.EnglishDescription)
            .NotEmpty().WithMessage("English description is required.")
            .MaximumLength(Constants.MaxDescriptionLength)
            .WithMessage($"English description cannot exceed {Constants.MaxDescriptionLength} characters.");

        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price must be greater than or equal to 0.");

        RuleFor(p => p.DiscountPercentage)
            .InclusiveBetween(0, 100)
            .WithMessage("Discount must be between 0 and 100.");

        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(p => p.CategoryId)
            .GreaterThan(0)
            .WithMessage("CategoryId must be valid.");

        RuleForEach(p => p.Attributes)
            .SetValidator(new ProductAttributeValueDtoValidator()!);
    }
}
