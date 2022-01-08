using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiSite.Data.Migrations
{
    public partial class add_image_to_food_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Foods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Foods");
        }
    }
}
