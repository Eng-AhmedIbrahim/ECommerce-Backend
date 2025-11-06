namespace Ecommerce.UseCases.CategoryUseCases.Command.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryService _categoryService;

    public DeleteCategoryCommandHandler(ICategoryService categoryService)
     => _categoryService = categoryService;
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        => await _categoryService.DeleteCategoryAsync(request.Id, cancellationToken);
}