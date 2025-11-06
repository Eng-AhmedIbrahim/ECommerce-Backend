namespace Ecommerce.Domain.Entities.CartEntities;

public class CartItem : BaseEntity, IDomainEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public string ProductName { get; set; } = string.Empty;
    public string ProductNameAr { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Dictionary<string, List<string>>? SelectedVariants { get; set; }

    public decimal? OriginalPrice { get; set; }
    public double? DiscountPercentage { get; set; }
}
