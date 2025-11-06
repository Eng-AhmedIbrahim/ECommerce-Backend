namespace Ecommerce.Persestense.Data.Configurations.BrachEntityConfigurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(b => b.Email)
            .HasMaxLength(150);

        builder.Property(b => b.AddressLine)
            .HasMaxLength(250);

        builder.Property(b => b.PictureUrl)
            .HasMaxLength(250);

        builder.Property(b => b.City)
            .HasMaxLength(100);

        builder.Property(b => b.State)
            .HasMaxLength(100);

        builder.Property(b => b.Country)
            .HasMaxLength(100);

        builder.Property(b => b.PostalCode)
            .HasMaxLength(20);

        builder.Property(b => b.Latitude)
            .HasPrecision(9, 6); // دقة GPS (خط العرض)

        builder.Property(b => b.Longitude)
            .HasPrecision(9, 6); // دقة GPS (خط الطول)

        builder.Property(b => b.IsActive)
            .HasDefaultValue(true);

        builder.Property(b => b.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(b => b.Company)
            .WithMany(c => c.Branches)
            .HasForeignKey(b => b.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
