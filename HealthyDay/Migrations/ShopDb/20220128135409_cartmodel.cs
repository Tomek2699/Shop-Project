using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyDay.Migrations.ShopDb
{
    public partial class cartmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartItemModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartItemModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartItemModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartItemModels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
