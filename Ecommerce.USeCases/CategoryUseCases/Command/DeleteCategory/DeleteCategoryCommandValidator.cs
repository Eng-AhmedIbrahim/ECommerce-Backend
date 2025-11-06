namespace Ecommerce.UseCases.CategoryUseCases.Command.DeleteCategory;

public class DeleteCategoryCommandValidator :AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Category Id must be greater than 0");
    }
}