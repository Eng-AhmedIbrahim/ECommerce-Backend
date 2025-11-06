using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Persestense.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocalicationForProductAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ProductVariant",
                newName: "EnglishValue");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductAttribute",
                newName: "EnglishName");

            migrationBuilder.AddColumn<string>(
                name: "ArabicValue",
                table: "ProductVariant",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArabicName",
                table: "ProductAttribute",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProductAttribute",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArabicName",
                value: "المقاس");

            migrationBuilder.UpdateData(
                table: "ProductAttribute",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArabicName",
                value: "اللون");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicValue",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "ArabicName",
                table: "ProductAttribute");

            migrationBuilder.RenameColumn(
                name: "EnglishValue",
                table: "ProductVariant",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "EnglishName",
                table: "ProductAttribute",
                newName: "Name");
        }
    }
}
