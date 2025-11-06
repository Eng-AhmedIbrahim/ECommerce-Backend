using Ecommerce.Domain.Entities.WishlistEntities;

namespace Ecommerce.Domain.Entities.Authentication;

public class AppUser : IdentityUser, IDomainEntity
{
    public string FullName { get; set; } = string.Empty;
    public string NormalizedFullName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public bool HasAcceptedTerms { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeleteTime { get; set; }
    public string? DeletedBy { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public ICollection<RefreshToken>? RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();

    public ICollection<Wishlist> WishlistItems { get; set; } = new List<Wishlist>();
}