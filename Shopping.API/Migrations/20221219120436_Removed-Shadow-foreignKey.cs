using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.API.Migrations
{
    public partial class RemovedShadowforeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId1",
                table: "Products",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerId1",
                table: "Products",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CustomerId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
