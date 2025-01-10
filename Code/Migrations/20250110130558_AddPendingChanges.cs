using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code.Migrations
{
    /// <inheritdoc />
    public partial class AddPendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 50, 58, 355, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 50, 58, 355, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 50, 58, 355, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 50, 58, 355, DateTimeKind.Local).AddTicks(1459));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 47, 46, 292, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 47, 46, 292, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 47, 46, 292, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 47, 46, 292, DateTimeKind.Local).AddTicks(1707));
        }
    }
}
