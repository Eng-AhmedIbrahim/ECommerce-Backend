using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Persestense.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Categories",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Categories");
        }
    }
}
