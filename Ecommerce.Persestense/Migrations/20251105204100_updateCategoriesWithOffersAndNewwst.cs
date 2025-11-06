using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Persestense.Migrations
{
    /// <inheritdoc />
    public partial class updateCategoriesWithOffersAndNewwst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ArabicDescription", "ArabicName", "EnglishDescription", "EnglishName", "Index" },
                values: new object[,]
                {
                    { 100, "قسم خاص بالعروض والخصومات.", "احدث العروض", "Special section for offers and discounts.", "Exclusive Offers", 1 },
                    { 101, "قسم يحتوي على أحدث المنتجات.", "الجديد من منعم", "Section containing the newest Menem products.", "Menem Newest Collection", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Categories");
        }
    }
}
