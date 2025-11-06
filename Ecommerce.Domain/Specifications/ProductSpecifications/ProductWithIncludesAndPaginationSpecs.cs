namespace Ecommerce.Domain.Specifications.ProductSpecifications;

public class ProductWithIncludesAndPaginationSpecs : BaseSpecifications<Product>
{
    public ProductWithIncludesAndPaginationSpecs(ProductSpecParams productSpec)
        : base(p =>
            (!productSpec.CategoryId.HasValue || p.CategoryId == productSpec.CategoryId) &&
            (
                string.IsNullOrEmpty(productSpec.Search) ||
                (
                    IsArabic(productSpec.Search)
                        ? p.ArabicName.ToLower().Contains(productSpec.Search.ToLower())
                        : p.EnglishName.ToLower().Contains(productSpec.Search.ToLower())
                )
            )
        )
    {
        if (!string.IsNullOrEmpty(productSpec.Sort))
        {
            switch (productSpec.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.EnglishName);
                    break;
            }
        }
        else if (!string.IsNullOrEmpty(productSpec.OrderByField))
        {
            var param = Expression.Parameter(typeof(Product), "p");

            try
            {
                var property = Expression.PropertyOrField(param, productSpec.OrderByField);

                var sortExpression = Expression.Lambda<Func<Product, object>>(
                    Expression.Convert(property, typeof(object)), param);

                if (productSpec.OrderDirection?.ToLower() == "desc")
                    AddOrderByDescending(sortExpression);
                else
                    AddOrderBy(sortExpression);
            }
            catch
            {
                AddOrderBy(p => p.EnglishName); 
            }
        }
        else
        {
            AddOrderBy(p => p.EnglishName);
        }

        ApplyPagination(
            productSpec.PageSize * (productSpec.PageIndex - 1),
            productSpec.PageSize
        );

        AddIncludes();
    }

    private static bool IsArabic(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        char c = text[0];
        return c >= 0x0600 && c <= 0x06FF;
    }

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
