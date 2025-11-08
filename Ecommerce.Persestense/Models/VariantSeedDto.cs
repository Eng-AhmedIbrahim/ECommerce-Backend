namespace Ecommerce.Persestense.Models;

public class VariantSeedDto
{
    public string EnglishValue { get; set; } = string.Empty;
    public string ArabicValue { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public int? StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
}
