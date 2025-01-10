using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 53, 25, 883, DateTimeKind.Local).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 53, 25, 883, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 53, 25, 883, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 18, 53, 25, 883, DateTimeKind.Local).AddTicks(1099));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
