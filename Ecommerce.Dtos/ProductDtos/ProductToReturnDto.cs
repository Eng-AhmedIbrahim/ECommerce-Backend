using Ecommerce.Dtos.ProductDtos.ProductReviewDtos;

namespace Ecommerce.Dtos.ProductDtos;

public class ProductToReturnDto
{
    public int Id { get; set; }
    public string ArabicName { get; set; } = string.Empty;
    public string EnglishName { get; set; } = string.Empty;
    public string ArabicDescription { get; set; } = string.Empty;
    public string EnglishDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; } = 0;
    public decimal DiscountedPrice => Price - (Price * DiscountPercentage / 100);
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public int CategoryId { get; set; }

    public ICollection<string> Images { get; set; } = new List<string>();

    public ICollection<ProductVariantToReturnDto> Variants { get; set; } = new List<ProductVariantToReturnDto>();

    public ICollection<ProductReviewsToReturnDto> ProductReviews { get; set; } = new List<ProductReviewsToReturnDto>();
}