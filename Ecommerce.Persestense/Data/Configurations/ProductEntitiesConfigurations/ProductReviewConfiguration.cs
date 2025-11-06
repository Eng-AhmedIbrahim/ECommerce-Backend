namespace Ecommerce.Persestense.Data.Configurations.ProductEntitiesConfigurations;

public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.HasKey(pr => pr.Id);

        builder.Property(pr => pr.Rating)
            .IsRequired();

        builder.Property(pr => pr.Comment)
            .HasMaxLength(Constants.CommentLength);

        builder.Property(pr => pr.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");


        builder.Property(pr => pr.UserName)
            .HasMaxLength(Constants.NameLength);

        builder.HasOne(pr => pr.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(pr => pr.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(pr => pr.UserId)
            .HasMaxLength(450)
            .IsRequired(false);

        builder.HasOne(pr => pr.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(pr => pr.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.ToTable("ProductReviews");
    }
}
