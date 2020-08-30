using Microsoft.EntityFrameworkCore.Migrations;

namespace store_application.API.Migrations
{
    public partial class ModifiedInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_ProductProdId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ProductProdId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ProductProdId",
                table: "Inventory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductProdId",
                table: "Inventory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductProdId",
                table: "Inventory",
                column: "ProductProdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProductProdId",
                table: "Inventory",
                column: "ProductProdId",
                principalTable: "Products",
                principalColumn: "ProdId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
