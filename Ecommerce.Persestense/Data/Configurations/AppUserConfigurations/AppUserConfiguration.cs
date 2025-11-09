namespace Ecommerce.Persestense.Data.Configurations.AppUserConfigurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.FullName)
            .HasMaxLength(Constants.NameLength)
            .IsRequired();

        builder.Property(u => u.NormalizedFullName)
            .HasMaxLength(Constants.NameLength)
            .IsRequired();

        builder.Property(u => u.ProfilePictureUrl)
            .HasMaxLength(Constants.ImageUrlLength);

        builder.Property(u => u.HasAcceptedTerms)
            .HasDefaultValue(false);

        builder.Property(u => u.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(u => u.IsActive)
            .HasDefaultValue(true);

        builder.Property(u => u.DeleteTime)
            .IsRequired(false);

        builder.Property(u => u.DeletedBy)
            .HasMaxLength(100);

        builder.Property(u => u.DateOfBirth)
            .HasColumnType("date");

        builder.HasMany(u => u.AppUserAddresses)
            .WithOne(a => a.AppUser)
            .HasForeignKey(a => a.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Orders)
            .WithOne(o => o.AppUser)
            .HasForeignKey(o => o.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.WishlistItems)
            .WithOne(w => w.AppUser)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Reviews)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.RefreshTokens)
           .WithOne()
           .HasForeignKey("UserId")
           .IsRequired();

        builder.HasMany(u => u.Reviews)
           .WithOne(u => u.User)
           .HasForeignKey("UserId")
           .IsRequired();
    }
}