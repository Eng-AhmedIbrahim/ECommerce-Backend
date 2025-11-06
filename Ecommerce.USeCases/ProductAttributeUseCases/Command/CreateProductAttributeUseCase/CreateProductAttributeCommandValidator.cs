namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.CreateProductAttributeUseCase;

public class CreateProductAttributeCommandValidator :AbstractValidator<CreateProductAttributeCommand>
{
    public CreateProductAttributeCommandValidator()
    {
        RuleFor(a=>a.AttributeDto.EnglishName)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(Constants.NameLength).WithMessage($"Name cannot exceed {Constants.NameLength} characters.");

        RuleFor(a => a.AttributeDto.ArabicName)
          .NotEmpty().WithMessage("Name is required.")
          .MaximumLength(Constants.NameLength).WithMessage($"Name cannot exceed {Constants.NameLength} characters.");
    }
}
