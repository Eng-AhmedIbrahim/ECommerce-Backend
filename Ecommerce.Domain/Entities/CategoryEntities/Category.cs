namespace Ecommerce.Domain.Entities.CategoryEntities;

public class Category :BaseEntity ,IDomainEntity
{
    public string ArabicName { get; set; } = string.Empty;
    public string EnglishName { get; set; } = string.Empty;
    public string ArabicDescription { get; set; } = string.Empty;
    public string EnglishDescription { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public int? Index { get; set; }
}
