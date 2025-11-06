namespace Ecommerce.Persestense.Data.Configurations.CartEntitiesConfigurations;

public class UserCartConfiguration : IEntityTypeConfiguration<UserCart>
{
    public void Configure(EntityTypeBuilder<UserCart> builder)
    {
        builder.ToTable("UserCarts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TotalItems)
               .IsRequired();

        builder.Property(x => x.TotalQuantity)
               .IsRequired();

        builder.Property(x => x.SubTotal)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(x => x.DiscountTotal)
               .HasColumnType("decimal(18,2)");

        builder.Property(x => x.GrandTotal)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(x => x.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(x => x.AppUser)
               .WithMany() 
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Items)
               .WithOne()
               .HasForeignKey("UserCartId")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
