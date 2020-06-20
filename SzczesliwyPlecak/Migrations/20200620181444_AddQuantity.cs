using Microsoft.EntityFrameworkCore.Migrations;

namespace SzczesliwyPlecak.Migrations
{
    public partial class AddQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripProduct_Product_ProductId",
                table: "TripProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TripProduct_Trip_TripId",
                table: "TripProduct");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "TripProduct",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "TripProduct",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TripProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TripProduct_Product_ProductId",
                table: "TripProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripProduct_Trip_TripId",
                table: "TripProduct",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripProduct_Product_ProductId",
                table: "TripProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TripProduct_Trip_TripId",
                table: "TripProduct");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TripProduct");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "TripProduct",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "TripProduct",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TripProduct_Product_ProductId",
                table: "TripProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripProduct_Trip_TripId",
                table: "TripProduct",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
