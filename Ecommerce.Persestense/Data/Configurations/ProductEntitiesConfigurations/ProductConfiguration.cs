namespace Ecommerce.Persestense.Data.Configurations.ProductEntitiesConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(c => c.ArabicName)
                .IsRequired()
                .HasMaxLength(Constants.NameLength);

        builder.Property(c => c.EnglishName)
           .IsRequired()
           .HasMaxLength(Constants.NameLength);

        builder.Property(c => c.ArabicDescription)
               .HasMaxLength(Constants.MaxDescriptionLength);

        builder.Property(c => c.EnglishDescription)
        .HasMaxLength(Constants.MaxDescriptionLength);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.DiscountPercentage)
            .HasColumnType("decimal(5,2)")
            .HasDefaultValue(0);

        builder.Ignore(p => p.DiscountedPrice);

        builder.Property(p => p.StockQuantity);

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true);

        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Images)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Variants)
        .WithOne(v => v.Product)
        .HasForeignKey(v => v.ProductId)
        .OnDelete(DeleteBehavior.Cascade);


        builder.ToTable("Products");
    }
}
