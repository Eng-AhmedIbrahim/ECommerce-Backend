namespace Ecommerce.UseCases.ProductUseCases.Command.UpdateProductCommandUseCase.UpdatedProductCommandValidation
{
    public class ProductAttributeValueDtoValidator : AbstractValidator<ProductAttributeValueDto>
    {
        public ProductAttributeValueDtoValidator()
        {
            RuleFor(a => a.AttributeId)
                .GreaterThan(0).WithMessage("AttributeId must be valid.");

            RuleFor(a => a.AttributeEnglishName)
                .NotEmpty().WithMessage("Attribute English name is required.")
                .MaximumLength(Constants.NameLength)
                .WithMessage($"Attribute English name cannot exceed {Constants.NameLength} characters.");

            RuleFor(a => a.AttributeArabicName)
                .NotEmpty().WithMessage("Attribute Arabic name is required.")
                .MaximumLength(Constants.NameLength)
                .WithMessage($"Attribute Arabic name cannot exceed {Constants.NameLength} characters.");

            RuleFor(a => a.EnglishValue)
                .NotEmpty().WithMessage("English value is required.")
                .MaximumLength(Constants.NameLength)
                .WithMessage($"English value cannot exceed {Constants.NameLength} characters.");

            RuleFor(a => a.ArabicValue)
                .NotEmpty().WithMessage("Arabic value is required.")
                .MaximumLength(Constants.NameLength)
                .WithMessage($"Arabic value cannot exceed {Constants.NameLength} characters.");

            RuleFor(a => a.Price)
                .GreaterThanOrEqualTo(0)
                .When(a => a.Price.HasValue);

            RuleFor(a => a.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .When(a => a.StockQuantity.HasValue);
        }
    }
}
