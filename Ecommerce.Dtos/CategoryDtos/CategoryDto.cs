namespace Ecommerce.Dtos.CategoryDtos;

public class CategoryDto
{
    [Required]
    public string? ArabicName { get; set; }
    [Required]
    public string? EnglishName { get; set; }
    public string? ArabicDescription { get; set; }
    public string? EnglishDescription { get; set; }
    public int? Index { get; set; }

}