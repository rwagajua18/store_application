using Microsoft.EntityFrameworkCore.Migrations;

namespace store_application.API.Migrations
{
    public partial class RemovedInventoryProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProductProdId",
                table: "Inventory",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "InventoryProdId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryStoreId",
                table: "Products",
                type: "int",
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
    }
}
