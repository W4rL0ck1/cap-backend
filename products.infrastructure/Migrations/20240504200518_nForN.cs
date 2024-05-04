using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products.infrastructure.Migrations
{
    public partial class nForN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Checkout_CheckoutId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CheckoutId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CheckoutProduct",
                columns: table => new
                {
                    CheckoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutProduct", x => new { x.CheckoutId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CheckoutProduct_Checkout_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkout",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutProduct_ProductsId",
                table: "CheckoutProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "CheckoutId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CheckoutId",
                table: "Products",
                column: "CheckoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Checkout_CheckoutId",
                table: "Products",
                column: "CheckoutId",
                principalTable: "Checkout",
                principalColumn: "ID");
        }
    }
}
