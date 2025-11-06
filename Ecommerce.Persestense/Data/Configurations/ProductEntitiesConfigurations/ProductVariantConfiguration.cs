namespace Ecommerce.Persestense.Data.Configurations.ProductEntitiesConfigurations;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.EnglishValue)
            .IsRequired()
            .HasMaxLength(Constants.NameLength);

        builder.Property(v => v.ArabicValue)
        .IsRequired()
        .HasMaxLength(Constants.NameLength);

        builder.Property(v => v.Price)
            .HasColumnType("decimal(18,2)");

        builder.Property(v => v.ImageUrl)
               .HasMaxLength(Constants.ImageUrlLength);

        builder.Property(v => v.StockQuantity)
            .HasDefaultValue(0);

        builder.HasOne(v => v.Product)
            .WithMany(p => p.Variants)
            .HasForeignKey(v => v.ProductId);

        builder.HasOne(v => v.ProductAttribute)
            .WithMany(a => a.Variants)
            .HasForeignKey(v => v.ProductAttributeId);
    }
}
