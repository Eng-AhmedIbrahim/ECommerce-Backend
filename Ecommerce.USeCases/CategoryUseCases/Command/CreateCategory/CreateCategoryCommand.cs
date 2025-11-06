namespace Ecommerce.UseCases.CategoryUseCases.Command.CreateCategory;

public record CreateCategoryCommand(
    string? ArabicName,
    string? EnglishName,
    string? ArabicDescription,
    string? EnglishDescription) : IRequest<Category>
{ }