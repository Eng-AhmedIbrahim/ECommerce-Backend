namespace Ecommerce.UseCases.CategoryUseCases.Query.GetCategoryQuery;

public record GetCategoryByIdQuery
    (int Id):IRequest<Category>
{}