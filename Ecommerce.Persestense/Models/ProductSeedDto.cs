namespace Ecommerce.Persestense.Models;

public class ProductSeedDto
{
    public string ArabicName { get; set; } = string.Empty;
    public string EnglishName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; }
    public int? StockQuantity { get; set; }
    public bool IsActive { get; set; }
    public List<string> Images { get; set; } = new();
    public List<VariantSeedDto> Variants { get; set; } = new();
}
