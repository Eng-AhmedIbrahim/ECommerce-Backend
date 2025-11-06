using System.Text.Encodings.Web;

namespace Ecommerce.Persestense.Data.Configurations.CartEntitiesConfigurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductId)
               .IsRequired();

        builder.Property(x => x.ProductName)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.ProductNameAr)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.ImageUrl)
               .HasMaxLength(500);

        builder.Property(x => x.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(x => x.Quantity)
               .IsRequired();

        builder.Property(x => x.OriginalPrice)
               .HasColumnType("decimal(18,2)");

        builder.Property(x => x.DiscountPercentage)
               .HasColumnType("float");

        builder.Property(x => x.SelectedVariants)
        .HasConversion(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }),
            v => string.IsNullOrEmpty(v)
                ? new Dictionary<string, List<string>>()
                : JsonSerializer.Deserialize<Dictionary<string, List<string>>>(v, new JsonSerializerOptions())
        )
        .HasColumnType("nvarchar(max)");

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
