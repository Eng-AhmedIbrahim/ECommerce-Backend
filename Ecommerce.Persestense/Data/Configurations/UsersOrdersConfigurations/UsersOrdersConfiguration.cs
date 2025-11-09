namespace Ecommerce.Persestense.Data.Configurations.UsersOrdersConfigurations;

public class UsersOrdersConfiguration : IEntityTypeConfiguration<UsersOrders>
{
    public void Configure(EntityTypeBuilder<UsersOrders> builder)
    {
        builder.ToTable("UsersOrders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.SubTotal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(o => o.DiscountAmount)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(o => o.ShippingCost)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(o => o.TotalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(o => o.OrderDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(o => o.AppUser)
            .WithMany()
            .HasForeignKey(o => o.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.AppUserAddress)
            .WithMany()
            .HasForeignKey(o => o.AppUserAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.OrderItems)
            .WithOne(i => i.UsersOrders)
            .HasForeignKey(i => i.UsersOrdersId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
