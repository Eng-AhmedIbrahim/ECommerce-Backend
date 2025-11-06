namespace Ecommerce.Domain.Entities.ProductEntities;

public class ProductVariant : BaseEntity, IDomainEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int ProductAttributeId { get; set; }
    public ProductAttribute ProductAttribute { get; set; } = null!;

    public string EnglishValue { get; set; } = string.Empty;
    public string ArabicValue { get; set; } = string.Empty; 
    public decimal? Price { get; set; }   
    public int? StockQuantity { get; set; } 
    public string? ImageUrl { get; set; }
}