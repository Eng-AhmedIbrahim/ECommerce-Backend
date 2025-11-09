namespace Ecommerce.Domain.Entities.OrderEntities.Enums;

public enum OrderStatus : byte
{
    Pending = 0,       // لسه متسجل بس
    Confirmed = 1,     // اتأكد من الأدمن أو السيستم
    Paid = 2,          // اتدفع
    Cancelled = 3,     // اتلغى
    Refunded = 4,    // اتعمله استرجاع
    Void = 5          // اتلغى وتم استرجاع المبلغ
}
