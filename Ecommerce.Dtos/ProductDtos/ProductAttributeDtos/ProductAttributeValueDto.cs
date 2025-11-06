namespace Ecommerce.Dtos.ProductDtos.ProductAttributeDtos;

public class ProductAttributeValueDto
{
    public int AttributeId { get; set; }
    public string AttributeEnglishName { get; set; } = string.Empty;
    public string AttributeArabicName { get; set; } = string.Empty;
    public string EnglishValue { get; set; } = string.Empty;
    public string ArabicValue { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public int? StockQuantity { get; set; }
    public IFormFile? AttributeImage { get; set; }
}