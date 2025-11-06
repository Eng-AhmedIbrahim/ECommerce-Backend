namespace Ecommerce.UseCases.ProductAttributeUseCases.Command.UpdateProductAttributeUseCase;

public class UpdateProductAttributeCommandValidator :AbstractValidator<UpdateProductAttributeCommand>
{
    public UpdateProductAttributeCommandValidator()
    {
        RuleFor(x => x.attId)
            .GreaterThan(0).WithMessage("Attribute ID must be greater than 0.");
        RuleFor(x => x.attributeDto)
            .NotEmpty().WithMessage("Attribute DTO cannot be empty.")
            .NotNull().WithMessage("Attribute DTO cannot be null.");

        RuleFor(x => x.attributeDto.EnglishName)
            .NotEmpty().WithMessage("Attribute name cannot be empty.")
            .MaximumLength(Constants.NameLength).WithMessage($"Attribute name cannot exceed {Constants.NameLength} characters.");

        RuleFor(x => x.attributeDto.ArabicName)
           .NotEmpty().WithMessage("Attribute name cannot be empty.")
           .MaximumLength(Constants.NameLength).WithMessage($"Attribute name cannot exceed {Constants.NameLength} characters.");
    }
}