namespace Ecommerce.Dtos.CategoryDtos;

public class CategoryToReturnDto
{
    public int Id { get; set; }
    public string ArabicName { get; set; } = string.Empty;
    public string EnglishName { get; set; } = string.Empty;
    public string ArabicDescription { get; set; } = string.Empty;
    public string EnglishDescription { get; set; } = string.Empty;
    public int? Index { get; set; }

}