namespace Ecommerce.Domain.Specifications.WishlistSpecifications;

public class GetWishlistByUserIdSpecs : BaseSpecifications<Wishlist>
{
    public GetWishlistByUserIdSpecs(string userId) :
        base(w => w.UserId == userId)
    {
    }
}
