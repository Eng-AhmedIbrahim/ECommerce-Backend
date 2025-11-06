namespace Ecommerce.UseCases.ProductUseCases.Command.CreateProductCommandUseCase.CreateProductValidations;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.ProductDto.ArabicName)
            .NotEmpty().WithMessage("Arabic Name is required")
            .MaximumLength(Constants.NameLength).WithMessage("Arabic Name must not exceed 200 characters");

        RuleFor(p => p.ProductDto.EnglishName)
            .NotEmpty().WithMessage("English Name is required")
            .MaximumLength(Constants.NameLength).WithMessage("English Name must not exceed 200 characters");

        RuleFor(p => p.ProductDto.Price)
            .NotEmpty().WithMessage("Price is required");

        RuleFor(p => p.ProductDto.Images)
            .NotNull().WithMessage("At least one image is required")
            .Must(images => images != null && images.Any())
            .WithMessage("At least one image is required");

        RuleFor(p => p.ProductDto.ArabicDescription)
            .MaximumLength(Constants.MaxDescriptionLength)
            .WithMessage($"Arabic Description must not exceed {Constants.MaxDescriptionLength} characters");

        RuleFor(p => p.ProductDto.EnglishDescription)
            .MaximumLength(Constants.MaxDescriptionLength)
            .WithMessage($"English Description must not exceed {Constants.MaxDescriptionLength} characters");

        RuleFor(p => p.ProductDto.DiscountPercentage)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Discount must be 0 or more")
            .LessThanOrEqualTo(100)
            .WithMessage("Discount must be less than or equal to 100");

        RuleFor(p => p.ProductDto.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock quantity cannot be negative");

        RuleFor(p => p.ProductDto.CategoryId)
            .GreaterThanOrEqualTo(0);


        RuleForEach(p => p.ProductDto.Attributes)
            .SetValidator(new ProductAttributeValueDtoValidator()!);
    }
}