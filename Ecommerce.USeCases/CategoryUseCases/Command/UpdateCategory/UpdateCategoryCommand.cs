using Microsoft.AspNetCore.JsonPatch;

namespace Ecommerce.UseCases.CategoryUseCases.Command.UpdateCategory;

public record UpdateCategoryCommand(
    int Id
    , UpdatedCategoryDto CategoryDto) : IRequest<CategoryToReturnDto>
{ }
