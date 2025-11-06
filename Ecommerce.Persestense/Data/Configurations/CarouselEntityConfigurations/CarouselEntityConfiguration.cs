namespace Ecommerce.Persestense.Data.Configurations.CarouselEntityConfigurations;

public class CarouselEntityConfiguration : IEntityTypeConfiguration<Carousel>
{
    public void Configure(EntityTypeBuilder<Carousel> builder)
    {
        builder.ToTable("Carousels");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.ImageUrl)
            .IsRequired()
            .HasMaxLength(Constants.MinDescriptionLength);

        builder.Property(c => c.ArabicTitle)
            .HasMaxLength(Constants.NameLength);

        builder.Property(c => c.EnglishTitle)
           .HasMaxLength(Constants.NameLength);

        builder.Property(c => c.ArabicDescription)
            .HasMaxLength(Constants.MinDescriptionLength);

        builder.Property(c => c.EnglishDescription)
            .HasMaxLength(Constants.MinDescriptionLength);

        builder.Property(c => c.Index)
            .HasDefaultValue(0)
            .IsRequired(false);
    }
}