namespace Ecommerce.Dtos.CarouselDtos;

public class CarouselDto
{
    [Required]
    public IFormFile ImageUrl { get; set; } = null!;
    public string? ArabicTitle { get; set; } 
    public string? EnglishTitle { get; set; } 
    public string? ArabicDescription { get; set; } 
    public string? EnglishDescription { get; set; }
    public int? Index { get; set; }
}