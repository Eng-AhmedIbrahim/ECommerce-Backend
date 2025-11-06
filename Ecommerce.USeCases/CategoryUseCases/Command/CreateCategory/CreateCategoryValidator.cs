namespace Ecommerce.UseCases.CategoryUseCases.Command.CreateCategory;

public class CreateCategoryValidator :AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.ArabicName)
            .NotEmpty().WithMessage("Category name is required.")
            .MaximumLength(Constants.NameLength).WithMessage("Category name must not exceed 100 characters.");

        RuleFor(c => c.EnglishName)
          .NotEmpty().WithMessage("Category name is required.")
          .MaximumLength(Constants.NameLength).WithMessage("Category name must not exceed 100 characters.");

        RuleFor(c => c.ArabicDescription)
          .NotEmpty().WithMessage("Category name is required.")
          .MaximumLength(Constants.NameLength).WithMessage("Category name must not exceed 100 characters.");

        RuleFor(c => c.EnglishDescription)
            .MaximumLength(Constants.MinDescriptionLength).WithMessage("Description must not exceed 500 characters.");
    }
}