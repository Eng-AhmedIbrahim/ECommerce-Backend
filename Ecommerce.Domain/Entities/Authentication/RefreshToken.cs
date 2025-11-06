namespace Ecommerce.Domain.Entities.Authentication;

public class RefreshToken :BaseEntity, IDomainEntity
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresOn { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
    public DateTime CreatedOn { get; set; }
    public DateTime? RevokedOn { get; set; }
    public bool IsActive => RevokedOn is null && !IsExpired;
    public string? UserId { get; set; }
}