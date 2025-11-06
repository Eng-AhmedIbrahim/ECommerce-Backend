namespace Ecommerce.Persestense.Data.Configurations.ProductEntitiesConfigurations;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.EnglishName)
            .IsRequired()
            .HasMaxLength(Constants.NameLength);

        builder.Property(a => a.ArabicName)
         .IsRequired()
         .HasMaxLength(Constants.NameLength);

        builder.HasMany(a => a.Variants)
            .WithOne(v => v.ProductAttribute)
            .HasForeignKey(v => v.ProductAttributeId)
            .OnDelete(DeleteBehavior.Cascade);



        builder.HasData(
            new ProductAttribute { Id = 1, EnglishName = "Size", ArabicName = "المقاس" },
            new ProductAttribute { Id = 2, EnglishName = "Color", ArabicName = "اللون" }
        );

    }
}
