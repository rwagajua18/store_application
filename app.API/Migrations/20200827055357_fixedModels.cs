using Microsoft.EntityFrameworkCore.Migrations;

namespace store_application.API.Migrations
{
    public partial class fixedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "catId",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "catId",
                table: "Products");
        }
    }
}
