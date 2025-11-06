namespace Ecommerce.Domain.Entities.ProductEntities;

public class ProductAttribute : BaseEntity, IDomainEntity
{
    public string EnglishName { get; set; } = string.Empty; // زي "Size", "Color", "Flavor"
    public string ArabicName { get; set; } = string.Empty; // زي "Size", "Color", "Flavor"

    public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
}
