namespace Ecommerce.UseCases.CategoryUseCases.Command.DeleteCategory
{
    public record DeleteCategoryCommand(int Id) : IRequest<bool> {}
}
