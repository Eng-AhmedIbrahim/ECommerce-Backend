namespace Ecommerce.Domain.Entities.CartEntities;

public class UserCart : BaseEntity, IDomainEntity
{
    public List<CartItem> Items { get; set; } = new();

    public int TotalItems { get; set; }
    public int TotalQuantity { get; set; }

    public decimal SubTotal { get; set; }
    public decimal? DiscountTotal { get; set; }
    public decimal GrandTotal { get; set; }

    public AppUser? AppUser { get; set; }
    public string? UserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
