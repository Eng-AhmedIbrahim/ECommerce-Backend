namespace Ecommerce.Domain.Specifications.WishlistSpecifications;

public class GetWishlistByUserIdAndProductIdSpecs : BaseSpecifications<Wishlist>
{
    public GetWishlistByUserIdAndProductIdSpecs(string userId, int productId)
        : base(w => w.UserId == userId && w.ProductId == productId)
    {
    }
}
