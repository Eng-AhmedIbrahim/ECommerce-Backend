using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Persestense.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrdersAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedFullName",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "HasAcceptedTerms",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "AppUserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserAddresses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserAddressId = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    WithoutShippingFee = table.Column<bool>(type: "bit", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    DeliveryStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVoided = table.Column<bool>(type: "bit", nullable: false),
                    VoidedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VoidedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoidReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersOrders_AppUserAddresses_AppUserAddressId",
                        column: x => x.AppUserAddressId,
                        principalTable: "AppUserAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersOrders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersOrders_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersOrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrderItems_UsersOrders_UsersOrdersId",
                        column: x => x.UsersOrdersId,
                        principalTable: "UsersOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAddresses_AppUserId",
                table: "AppUserAddresses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderItems_ProductId",
                table: "UserOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderItems_UsersOrdersId",
                table: "UserOrderItems",
                column: "UsersOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOrders_AppUserAddressId",
                table: "UsersOrders",
                column: "AppUserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOrders_AppUserId",
                table: "UsersOrders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOrders_AppUserId1",
                table: "UsersOrders",
                column: "AppUserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOrderItems");

            migrationBuilder.DropTable(
                name: "UsersOrders");

            migrationBuilder.DropTable(
                name: "AppUserAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedFullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasAcceptedTerms",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
