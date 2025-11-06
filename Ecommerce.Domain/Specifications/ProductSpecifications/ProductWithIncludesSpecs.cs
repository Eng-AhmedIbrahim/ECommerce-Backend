namespace Ecommerce.Domain.Specifications.ProductSpecifications;

public class ProductWithIncludesSpecs : BaseSpecifications<Product>
{
    public ProductWithIncludesSpecs(int productId) : base(p => p.Id == productId)
     =>   AddIncludes();

    public ProductWithIncludesSpecs()
     =>   AddIncludes();

    private void AddIncludes()
    {
        Includes!.Add(p => p.Images!);
        Includes!.Add(p => p.Category!);
        Includes!.Add(p => p.Variants!);
        IncludeStrings!.Add("Variants.ProductAttribute");
        Includes!.Add(p => p.Reviews!);
        IncludeStrings!.Add("Reviews.User");
    }
}