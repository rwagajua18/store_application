using Microsoft.EntityFrameworkCore.Migrations;

namespace store_application.API.Migrations
{
    public partial class FixRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProdId",
                table: "Inventory",
                column: "ProdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProdId",
                table: "Inventory",
                column: "ProdId",
                principalTable: "Products",
                principalColumn: "ProdId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_ProdId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ProdId",
                table: "Inventory");
        }
    }
}
