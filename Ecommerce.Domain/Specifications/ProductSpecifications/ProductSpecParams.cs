namespace Ecommerce.Domain.Specifications.ProductSpecifications;

public class ProductSpecParams
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 10;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
    public string? Search { get; set; }
    public int? CategoryId { get; set; }
    public string? Sort { get; set; } 
    public string? OrderByField { get; set; }
    public string? OrderDirection { get; set; }

}