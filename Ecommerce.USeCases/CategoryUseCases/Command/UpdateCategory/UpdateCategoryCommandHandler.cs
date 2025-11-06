namespace Ecommerce.UseCases.CategoryUseCases.Command.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryToReturnDto>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryCommandHandler(ICategoryService categoryService)
     => _categoryService = categoryService;
    public Task<CategoryToReturnDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        => _categoryService.UpdateCategoryAsync(request.Id, request.CategoryDto, cancellationToken);
}