using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePasswordColumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 421, DateTimeKind.Utc).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 421, DateTimeKind.Utc).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 421, DateTimeKind.Utc).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 421, DateTimeKind.Utc).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 421, DateTimeKind.Utc).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 422, DateTimeKind.Utc).AddTicks(952));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 422, DateTimeKind.Utc).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 422, DateTimeKind.Utc).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 15, 4, 0, 39, 422, DateTimeKind.Utc).AddTicks(1150));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
