namespace Ecommerce.Persestense.Data.Configurations.CategoryEntitiesConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.ArabicName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.EnglishName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.ArabicDescription)
                   .HasMaxLength(500);

            builder.Property(c => c.EnglishDescription)
                   .HasMaxLength(500);

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Index)
                     .IsRequired(false);

            builder.HasData(
   new
   {
       Id = 100,
       ArabicName = "احدث العروض",
       EnglishName = "Exclusive Offers",
       ArabicDescription = "قسم خاص بالعروض والخصومات.",
       EnglishDescription = "Special section for offers and discounts.",
       Index = 1
   },
   new
   {
       Id = 101,
       ArabicName = "الجديد من منعم",
       EnglishName = "Menem Newest Collection",
       ArabicDescription = "قسم يحتوي على أحدث المنتجات.",
       EnglishDescription = "Section containing the newest Menem products.",
       Index = 2
   }
);
        }
    }
}
