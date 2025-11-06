namespace Ecommerce.Persestense.Data.Configurations.ProductEntitiesConfigurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(pi => pi.Id);

        builder.Property(pi => pi.Url)
            .IsRequired()
            .HasMaxLength(Constants.ImageUrlLength);

        builder.Property(pi => pi.IsMain)
            .HasDefaultValue(false);

        builder.HasOne(pi => pi.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("ProductImages");
    }
}