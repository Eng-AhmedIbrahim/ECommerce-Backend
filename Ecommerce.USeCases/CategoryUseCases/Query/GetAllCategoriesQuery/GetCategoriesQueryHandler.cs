namespace Ecommerce.UseCases.CategoryUseCases.Query.GetAllCategoriesQuery;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IReadOnlyList<Category>?>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesQueryHandler(ICategoryService categoryService)
     => _categoryService = categoryService;

    public async Task<IReadOnlyList<Category>?> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        => await _categoryService.GetAllCategoriesAsync(cancellationToken);
}