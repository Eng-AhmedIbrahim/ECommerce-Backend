namespace Ecommerce.Dtos.CarouselDtos;

public class CarouselToReturnDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string? ArabicTitle { get; set; } = string.Empty;
    public string? EnglishTitle { get; set; } = string.Empty;
    public string? ArabicDescription { get; set; } = string.Empty;
    public string? EnglishDescription { get; set; } = string.Empty;
    public int Index { get; set; } = 0;

}