namespace Ecommerce.Persestense.Data.Configurations.CompanyEntityConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
              .IsRequired()
              .HasMaxLength(200);

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.Property(c => c.Industry)
            .HasMaxLength(100);

        builder.Property(c => c.Email)
            .HasMaxLength(150);

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(c => c.WebsiteUrl)
            .HasMaxLength(250);

        builder.Property(c => c.LogoUrl)
            .HasMaxLength(250);

        builder.Property(c => c.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasMany(c => c.Branches)
              .WithOne(b => b.Company)
              .HasForeignKey(b => b.CompanyId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}