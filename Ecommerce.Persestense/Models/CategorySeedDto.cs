namespace Ecommerce.Persestense.Models;

internal class CategorySeedDto
{
    public int Index { get; set; }
    public string ArabicName { get; set; } = string.Empty;
    public string EnglishName { get; set; } = string.Empty;
    public string ArabicDescription { get; set; } = string.Empty;
    public string EnglishDescription { get; set; } = string.Empty;
    public List<ProductSeedDto> Products { get; set; } = new();
}
