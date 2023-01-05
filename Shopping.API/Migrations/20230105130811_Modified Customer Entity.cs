using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.API.Migrations
{
    public partial class ModifiedCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerCreatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CustomerNumber",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerCreatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Customers");

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
    }
}
