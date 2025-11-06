namespace Ecommerce.Domain.Entities.ProductEntities;

public class Product : BaseEntity, IDomainEntity
{
    public string ArabicName { get; set; } = string.Empty;
    public string EnglishName { get; set; } = string.Empty;
    public string? ArabicDescription { get; set; } = string.Empty;
    public string? EnglishDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; } = 0;
    public decimal DiscountedPrice => Price - (Price * DiscountPercentage / 100);

    public int? StockQuantity { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<ProductImage>? Images { get; set; } = new List<ProductImage>();
    public ICollection<ProductReview>? Reviews { get; set; } = new List<ProductReview>();
    public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    public ICollection<Wishlist>? Wishlists { get; set; } = new List<Wishlist>();
}