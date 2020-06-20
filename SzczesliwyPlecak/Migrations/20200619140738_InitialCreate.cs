using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SzczesliwyPlecak.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Calories = table.Column<float>(nullable: false),
                    Fat = table.Column<float>(nullable: false),
                    Carbohydrates = table.Column<float>(nullable: false),
                    Fibre = table.Column<float>(nullable: false),
                    Proteins = table.Column<float>(nullable: false),
                    Salt = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DurationInDays = table.Column<int>(nullable: false),
                    CaloriesNeeded = table.Column<float>(nullable: false),
                    FatNeeded = table.Column<float>(nullable: false),
                    CarbohydratesNeeded = table.Column<float>(nullable: false),
                    FibreNeeded = table.Column<float>(nullable: false),
                    ProteinsNeeded = table.Column<float>(nullable: false),
                    SaltNeeded = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripProduct_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripProduct_ProductId",
                table: "TripProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TripProduct_TripId",
                table: "TripProduct",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
