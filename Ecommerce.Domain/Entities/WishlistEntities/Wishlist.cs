namespace Ecommerce.Domain.Entities.WishlistEntities;

public class Wishlist : BaseEntity , IDomainEntity
{
    public string UserId { get; set; } = string.Empty;
    public AppUser? AppUser { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}