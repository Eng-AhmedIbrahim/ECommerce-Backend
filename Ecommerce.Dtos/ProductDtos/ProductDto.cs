using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Dtos.ProductDtos;

public class ProductDto
{
    [Required]
    public string ArabicName { get; set; } = string.Empty;
    [Required]
    public string EnglishName { get; set; } = string.Empty;
    [Required]
    public string ArabicDescription { get; set; } = string.Empty;
    [Required]
    public string EnglishDescription { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; } = 0;
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; } = true;
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public List<IFormFile>? Images { get; set; }
    //public List<string>? Images { get; set; }
    public string? AttributesJson { get; set; }
    [NotMapped]
    [BindNever]
    public List<ProductAttributeValueDto>? Attributes { get; set; }
}