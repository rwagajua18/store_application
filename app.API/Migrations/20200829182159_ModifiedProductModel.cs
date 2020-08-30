using Microsoft.EntityFrameworkCore.Migrations;

namespace store_application.API.Migrations
{
    public partial class ModifiedProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryProdId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryStoreId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryStoreId_InventoryProdId",
                table: "Products",
                columns: new[] { "InventoryStoreId", "InventoryProdId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Inventory_InventoryStoreId_InventoryProdId",
                table: "Products",
                columns: new[] { "InventoryStoreId", "InventoryProdId" },
                principalTable: "Inventory",
                principalColumns: new[] { "StoreId", "ProdId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Inventory_InventoryStoreId_InventoryProdId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryStoreId_InventoryProdId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryProdId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryStoreId",
                table: "Products");
        }
    }
}
