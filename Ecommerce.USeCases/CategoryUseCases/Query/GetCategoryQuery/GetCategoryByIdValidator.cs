namespace Ecommerce.UseCases.CategoryUseCases.Query.GetCategoryQuery;

public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Category Id is required")
            .GreaterThan(0)
            .WithMessage("Category Id must be greater than 0");
    }
}