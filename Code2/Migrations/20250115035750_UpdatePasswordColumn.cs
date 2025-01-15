using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePasswordColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(2917));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 15, 3, 57, 49, 277, DateTimeKind.Utc).AddTicks(6030));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 321, DateTimeKind.Utc).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 321, DateTimeKind.Utc).AddTicks(2737));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 321, DateTimeKind.Utc).AddTicks(2739));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 14, 11, 0, 11, 321, DateTimeKind.Utc).AddTicks(2741));
        }
    }
}
