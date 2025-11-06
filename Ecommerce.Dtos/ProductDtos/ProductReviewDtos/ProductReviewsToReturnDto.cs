namespace Ecommerce.Dtos.ProductDtos.ProductReviewDtos;

public class ProductReviewsToReturnDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = "Unknown";
    public int Rating { get; set; } 
    public string? Comment { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}