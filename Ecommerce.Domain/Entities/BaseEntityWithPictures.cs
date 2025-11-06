namespace Ecommerce.Domain.Entities;

public class BaseEntityWithPictures :BaseEntity , IDomainEntity
{
    public List<string> PictureUrls { get; set; } = new();
}

