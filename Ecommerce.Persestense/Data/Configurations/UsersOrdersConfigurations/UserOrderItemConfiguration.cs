namespace Ecommerce.Persestense.Data.Configurations.UsersOrdersConfigurations;

public class UserOrderItemConfiguration : IEntityTypeConfiguration<UserOrderItem>
{
    public void Configure(EntityTypeBuilder<UserOrderItem> builder)
    {
        builder.ToTable("UserOrderItems");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.ProductName)
            .HasMaxLength(Constants.NameLength)
            .IsRequired();

        builder.Property(i => i.ProductImageUrl)
            .HasMaxLength(Constants.ImageUrlLength);

        builder.Property(i => i.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(i => i.Quantity)
            .IsRequired();

        builder.HasOne(i => i.UsersOrders)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(i => i.UsersOrdersId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
