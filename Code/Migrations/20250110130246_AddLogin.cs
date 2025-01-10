using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Code.Migrations
{
    /// <inheritdoc />
    public partial class AddLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 18, 47, 46, 292, DateTimeKind.Local).AddTicks(1431), "admin@example.com", "Admin@123", "Admin", "admin" },
                    { 2, new DateTime(2025, 1, 10, 18, 47, 46, 292, DateTimeKind.Local).AddTicks(1703), "client1@example.com", "Client1@123", "Client", "client1" },
                    { 3, new DateTime(2025, 1, 10, 18, 47, 46, 292, DateTimeKind.Local).AddTicks(1705), "client2@example.com", "Client2@123", "Client", "client2" },
                    { 4, new DateTime(2025, 1, 10, 18, 47, 46, 292, DateTimeKind.Local).AddTicks(1707), "client3@example.com", "Client3@123", "Client", "client3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");
        }
    }
}
