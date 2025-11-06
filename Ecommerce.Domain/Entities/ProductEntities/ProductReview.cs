namespace Ecommerce.Domain.Entities.ProductEntities;

public class ProductReview : BaseEntity, IDomainEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public string? UserId { get; set; }
    public AppUser? User { get; set; }

    public string? UserName { get; set; } = string.Empty;

    public int Rating { get; set; }
    public string? Comment { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}