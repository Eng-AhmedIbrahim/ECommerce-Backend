namespace Ecommerce.Domain.Entities.CarouselEntity;

public class Carousel : BaseEntity, IDomainEntity
{
    public string ImageUrl { get; set; } = string.Empty;
    public string? ArabicTitle { get; set; } = string.Empty;
    public string? EnglishTitle { get; set; } = string.Empty;
    public string? ArabicDescription { get; set; } = string.Empty;
    public string? EnglishDescription { get; set; } = string.Empty;
    public int? Index { get; set; }
}