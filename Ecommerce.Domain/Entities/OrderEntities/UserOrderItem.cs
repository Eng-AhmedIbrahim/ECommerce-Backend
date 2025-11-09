namespace Ecommerce.Domain.Entities.OrderEntities;

public class UserOrderItem : BaseEntity, IDomainEntity
{
    public int UsersOrdersId { get; set; }
    public UsersOrders UsersOrders { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public string ProductName { get; set; } = string.Empty;
    public string? ProductImageUrl { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;
}
