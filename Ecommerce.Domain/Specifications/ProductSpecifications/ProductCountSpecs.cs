namespace Ecommerce.Domain.Specifications.ProductSpecifications;

public class ProductCountSpecs : BaseSpecifications<Product>
{
    public ProductCountSpecs(int? categoryId = null) :
        base(p =>
        !categoryId.HasValue || p.CategoryId == categoryId)
    { }
}