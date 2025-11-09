namespace Ecommerce.Domain.Entities.OrderEntities.Enums;

public enum PaymentMethods : byte
{
    Cash = 0,            // الدفع عند الاستلام
    Visa = 1,           // كارت بنكي / فيزا
}