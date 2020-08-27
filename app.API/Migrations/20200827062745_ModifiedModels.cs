using Microsoft.EntityFrameworkCore.Migrations;

namespace store_application.API.Migrations
{
    public partial class ModifiedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categorycatID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_categorycatID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProdId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "catId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "categorycatID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "catID",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Products",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryID",
                table: "Products",
                column: "categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryID",
                table: "Products",
                column: "categoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_categoryID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ProdId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "catId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categorycatID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "catID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "catID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categorycatID",
                table: "Products",
                column: "categorycatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categorycatID",
                table: "Products",
                column: "categorycatID",
                principalTable: "Categories",
                principalColumn: "catID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
