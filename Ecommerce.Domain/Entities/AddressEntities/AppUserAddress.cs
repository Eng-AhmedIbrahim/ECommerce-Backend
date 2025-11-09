namespace Ecommerce.Domain.Entities.AddressEntities;

public class AppUserAddress : BaseEntity ,IDomainEntity
{
    public string AppUserId { get; set; } = string.Empty;
    public AppUser AppUser { get; set; } = null!;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public bool IsDefault { get; set; } = false;
}
