namespace Ecommerce.UseCases.CategoryUseCases.Command.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Category?>
{
    private readonly IMapper _mapper;
    private readonly ICategoryService _categoryService;

    public CreateCategoryHandler(IMapper mapper,ICategoryService categoryService)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }
    public async Task<Category?> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryDto = _mapper.Map<CreateCategoryCommand, CategoryDto>(request);

        return await _categoryService.CreateCategoryAsync(categoryDto, cancellationToken);
    }
}