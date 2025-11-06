namespace Ecommerce.Dtos.ProductDtos.ProductReviewDtos;

public class ProductReviewDto
{
    public int ProductId { get; set; }
    public string? UserId { get; set; } 
    public int? Rating { get; set; } = 0;
    public string? Comment { get; set; }
    public string? UserName { get; set; } = "Unknown";
}