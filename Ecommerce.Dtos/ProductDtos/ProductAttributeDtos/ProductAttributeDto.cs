namespace Ecommerce.Dtos.ProductDtos.ProductAttributeDtos;

public class ProductAttributeDto
{
    [Required]
    public string EnglishName { get; set; } = string.Empty;
    [Required]
    public string ArabicName { get; set; } = string.Empty;
}