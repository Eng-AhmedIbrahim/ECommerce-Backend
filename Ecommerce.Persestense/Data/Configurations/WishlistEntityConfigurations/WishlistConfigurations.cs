namespace Ecommerce.Persestense.Data.Configurations.WishlistEntityConfigurations
{
    public class WishlistConfigurations : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("Wishlists");

            builder.HasKey(w => w.Id);


            builder.HasOne(u=>u.AppUser)
                .WithMany(u=>u.WishlistItems)
                .HasForeignKey(w=>w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Wishlists)
                .HasForeignKey(w => w.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(w => w.CreatedAt)
              .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
