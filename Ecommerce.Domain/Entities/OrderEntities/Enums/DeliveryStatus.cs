namespace Ecommerce.Domain.Entities.OrderEntities.Enums;

public enum DeliveryStatus : byte
{
    Preparing = 0,     // بيجهز
    OutForDelivery = 1,// في الطريق
    Delivered = 2,     // اتسلم
    Failed = 3         // فشل التوصيل
}
