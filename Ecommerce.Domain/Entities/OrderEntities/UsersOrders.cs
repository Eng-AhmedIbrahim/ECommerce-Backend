namespace Ecommerce.Domain.Entities.OrderEntities;

public class UsersOrders : BaseEntity, IDomainEntity
{
    public string AppUserId { get; set; } = string.Empty;
    public AppUser AppUser { get; set; } = null!;

    public int AppUserAddressId { get; set; }
    public AppUserAddress AppUserAddress { get; set; } = null!;

    public decimal SubTotal { get; set; }
    public bool HasDiscount { get; set; } = false;
    public decimal DiscountAmount { get; set; } = 0;
    public decimal ShippingCost { get; set; } = 0;
    public bool WithoutShippingFee { get; set; } = false;
    public decimal TotalAmount { get; set; }

    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.Preparing;
    public PaymentMethods PaymentMethod { get; set; } = PaymentMethods.Cash;
    public bool IsPaid { get; set; } = false;


    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? ShippingDate { get; set; }
    public DateTime? ReceivedDate { get; set; }
    public DateTime? ClosedDate { get; set; }

    public bool IsVoided { get; set; } = false;
    public DateTime? VoidedAt { get; set; }
    public string? VoidedBy { get; set; }
    public string? VoidReason { get; set; }
    public string? CustomerNote { get; set; }

    public ICollection<UserOrderItem> OrderItems { get; set; } = new List<UserOrderItem>();
}
