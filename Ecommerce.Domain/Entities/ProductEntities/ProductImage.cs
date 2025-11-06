namespace Ecommerce.Domain.Entities.ProductEntities;

public class ProductImage : BaseEntity, IDomainEntity
{
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}