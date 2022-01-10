using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiSite.Data.Migrations
{
    public partial class change_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FoodId",
                table: "Orders",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Foods_FoodId",
                table: "Orders",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Foods_FoodId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FoodId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Orders");
        }
    }
}
