namespace Ecommerce.UseCases.ProductUseCases.Command.CreateProductCommandUseCase.CreateProductValidations;

public class ProductAttributeValueDtoValidator :  AbstractValidator<ProductAttributeValueDto>
{
    public ProductAttributeValueDtoValidator()
    {
        RuleFor(a => a.AttributeId)
            .GreaterThan(0).WithMessage("AttributeId must be valid.");

        RuleFor(a => a.AttributeEnglishName)
            .NotEmpty().WithMessage("Attribute English name is required.");

        RuleFor(a => a.AttributeArabicName)
            .NotEmpty().WithMessage("Attribute Arabic name is required.");

        RuleFor(a => a.EnglishValue)
            .NotEmpty().WithMessage("English value is required.");

        RuleFor(a => a.ArabicValue)
            .NotEmpty().WithMessage("Arabic value is required.");

        RuleFor(a => a.Price)
            .GreaterThanOrEqualTo(0).When(a => a.Price.HasValue);

        RuleFor(a => a.StockQuantity)
            .GreaterThanOrEqualTo(0).When(a => a.StockQuantity.HasValue);
    }
}
