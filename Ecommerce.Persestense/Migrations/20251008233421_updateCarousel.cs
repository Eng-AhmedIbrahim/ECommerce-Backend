using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Persestense.Migrations
{
    /// <inheritdoc />
    public partial class updateCarousel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Carousels",
                newName: "EnglishTitle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Carousels",
                newName: "EnglishDescription");

            migrationBuilder.AddColumn<string>(
                name: "ArabicDescription",
                table: "Carousels",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArabicTitle",
                table: "Carousels",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicDescription",
                table: "Carousels");

            migrationBuilder.DropColumn(
                name: "ArabicTitle",
                table: "Carousels");

            migrationBuilder.RenameColumn(
                name: "EnglishTitle",
                table: "Carousels",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "EnglishDescription",
                table: "Carousels",
                newName: "Description");
        }
    }
}
