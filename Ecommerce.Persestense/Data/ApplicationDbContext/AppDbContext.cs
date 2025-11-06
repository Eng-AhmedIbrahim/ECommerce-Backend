namespace Ecommerce.Persestense.Data.ApplicationDbContext;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<Carousel> Carousels { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        builder.Entity<AppUser>()
            .HasMany(u => u.RefreshTokens)
            .WithOne()
            .HasForeignKey("UserId")
            .IsRequired();

        builder.Entity<AppUser>()
           .HasMany(u => u.Reviews)
           .WithOne(u=>u.User)
           .HasForeignKey("UserId")
           .IsRequired();

        base.OnModelCreating(builder);
    }
}