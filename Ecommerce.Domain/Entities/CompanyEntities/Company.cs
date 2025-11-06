namespace Ecommerce.Domain.Entities.CompanyEntities;

public class Company : BaseEntity, IDomainEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }                  
    public string? Industry { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? LogoUrl { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
}