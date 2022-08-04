using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SemOrder.Model.Migrations
{
    public partial class propertyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("b43869c2-e8be-4ced-ae13-7b3555f18310"));

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Food",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Email", "FirstName", "ImageUrl", "LastName", "Password", "Phone", "Status" },
                values: new object[] { new Guid("fbef8107-492c-4c8f-ac84-d1fee5f56bc2"), "admin@admin.com", "Admin", "/", "ADMIN", "123", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("fbef8107-492c-4c8f-ac84-d1fee5f56bc2"));

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Food");

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Email", "FirstName", "ImageUrl", "LastName", "Password", "Phone", "Status" },
                values: new object[] { new Guid("b43869c2-e8be-4ced-ae13-7b3555f18310"), "admin@admin.com", "Admin", "/", "ADMIN", "123", null, 1 });
        }
    }
}
