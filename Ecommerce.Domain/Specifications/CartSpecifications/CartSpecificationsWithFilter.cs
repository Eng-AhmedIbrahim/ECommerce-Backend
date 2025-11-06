using Ecommerce.Domain.Entities.CartEntities;

namespace Ecommerce.Domain.Specifications.CartSpecifications;

public class CartSpecificationsWithFilter : BaseSpecifications<UserCart>
{
    public CartSpecificationsWithFilter(string userId) : base(c => c.UserId == userId)
    {
        Includes?.Add(c => c.Items);
    }
}
    