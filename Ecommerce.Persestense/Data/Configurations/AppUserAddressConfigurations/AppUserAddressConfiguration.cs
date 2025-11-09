namespace Ecommerce.Persestense.Data.Configurations.AppUserAddressConfigurations;

public class AppUserAddressConfiguration : IEntityTypeConfiguration<AppUserAddress>
{
    public void Configure(EntityTypeBuilder<AppUserAddress> builder)
    {
        builder.ToTable("AppUserAddresses");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.AddressLine1)
            .HasMaxLength(Constants.AddressLineLength)
            .IsRequired();

        builder.Property(a => a.AddressLine2)
            .HasMaxLength(Constants.AddressLineLength);

        builder.Property(a => a.City)
            .HasMaxLength(Constants.CityLength)
            .IsRequired();

        builder.Property(a => a.State)
            .HasMaxLength(Constants.CityLength)
            .IsRequired();

        builder.Property(a => a.Country)
            .HasMaxLength(Constants.CityLength)
            .IsRequired();

        builder.Property(a => a.PhoneNumber)
            .HasMaxLength(Constants.PhoneNumber);

        builder.HasOne(a => a.AppUser)
            .WithMany(a=>a.AppUserAddresses)
            .HasForeignKey(a => a.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}