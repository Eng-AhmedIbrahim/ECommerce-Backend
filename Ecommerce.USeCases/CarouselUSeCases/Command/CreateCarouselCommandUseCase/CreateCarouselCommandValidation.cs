namespace Ecommerce.UseCases.CarouselUSeCases.Command.CreateCarouselCommandUseCase;

public class CreateCarouselCommandValidation :AbstractValidator<CreateCarouselCommand>
{
    public CreateCarouselCommandValidation()
    {
        RuleFor(x => x.CarouselDto.ImageUrl)
            .NotNull().WithMessage("Image is required.")
            .Must(file => file.Length > 0).WithMessage("Image file cannot be empty.")
            .Must(file =>
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
                var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
                return !string.IsNullOrEmpty(extension) && allowedExtensions.Contains(extension);
            })
            .WithMessage("Only image files (.jpg, .jpeg, .png, .webp) are allowed.");

        RuleFor(x => x.CarouselDto.ArabicTitle)
             .MaximumLength(Constants.NameLength)
             .WithMessage("ArabicTitle cannot exceed 100 characters.");

        RuleFor(x => x.CarouselDto.EnglishTitle)
          .MaximumLength(Constants.NameLength)
          .WithMessage("EnglishTitle cannot exceed 100 characters.");

        RuleFor(x => x.CarouselDto.EnglishDescription)
            .MaximumLength(Constants.MinDescriptionLength)
            .WithMessage("Description cannot exceed 250 characters.");


        RuleFor(x => x.CarouselDto.ArabicDescription)
            .MaximumLength(Constants.MinDescriptionLength)
            .WithMessage("Description cannot exceed 250 characters.");
    }
}