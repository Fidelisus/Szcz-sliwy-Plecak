using Microsoft.EntityFrameworkCore.Migrations;

namespace SzczesliwyPlecak.Migrations
{
    public partial class TripUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FemaleParticipants",
                table: "Trip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaleParticipants",
                table: "Trip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTimeHiking",
                table: "Trip",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FemaleParticipants",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "MaleParticipants",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "TotalTimeHiking",
                table: "Trip");
        }
    }
}
