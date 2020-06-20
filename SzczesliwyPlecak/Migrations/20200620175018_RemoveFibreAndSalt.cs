using Microsoft.EntityFrameworkCore.Migrations;

namespace SzczesliwyPlecak.Migrations
{
    public partial class RemoveFibreAndSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FibreNeeded",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "SaltNeeded",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Fibre",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FibreNeeded",
                table: "Trip",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SaltNeeded",
                table: "Trip",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fibre",
                table: "Product",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Salt",
                table: "Product",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
