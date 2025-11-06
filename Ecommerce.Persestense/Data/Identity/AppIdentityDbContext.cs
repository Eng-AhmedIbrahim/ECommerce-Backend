namespace Ecommerce.Persestense.Data.Identity;

public class AppIdentityDbContext : IdentityDbContext<AppUser,IdentityRole,string>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AppUser>()
       .HasMany(u => u.RefreshTokens)
       .WithOne()
       .HasForeignKey("UserId")
       .IsRequired();

        base.OnModelCreating(builder);
    }

    public DbSet<RefreshToken> RefreshTokens { get; set; }
}