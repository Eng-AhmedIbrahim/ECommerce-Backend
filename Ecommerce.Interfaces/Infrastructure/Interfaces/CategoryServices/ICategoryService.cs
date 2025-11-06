using Microsoft.AspNetCore.JsonPatch;

namespace Ecommerce.Interfaces.Infrastructure.Interfaces.CategoryServices;

public interface ICategoryService
{
    Task<Category?> CreateCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken = default);
    Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Category>?> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    Task<bool> DeleteCategoryAsync(int id, CancellationToken cancellationToken = default);
    Task<CategoryToReturnDto> UpdateCategoryAsync(int id, UpdatedCategoryDto categoryDto, CancellationToken cancellationToken = default);
}  