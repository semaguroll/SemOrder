using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SemOrder.Model.Migrations
{
    public partial class foreignkeychanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Order_OrderId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_OrderId",
                table: "Food");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("5f79c7ad-0211-448a-8247-260da25745aa"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Food");

            migrationBuilder.AddColumn<Guid>(
                name: "FoodId",
                table: "Order",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Email", "FirstName", "ImageUrl", "LastName", "Password", "Phone", "Status" },
                values: new object[] { new Guid("b43869c2-e8be-4ced-ae13-7b3555f18310"), "admin@admin.com", "Admin", "/", "ADMIN", "123", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Order_FoodId",
                table: "Order",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Food_FoodId",
                table: "Order",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Food_FoodId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_FoodId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("b43869c2-e8be-4ced-ae13-7b3555f18310"));

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Food",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Email", "FirstName", "ImageUrl", "LastName", "Password", "Phone", "Status" },
                values: new object[] { new Guid("5f79c7ad-0211-448a-8247-260da25745aa"), "admin@admin.com", "Admin", "/", "ADMIN", "123", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Food_OrderId",
                table: "Food",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Order_OrderId",
                table: "Food",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
