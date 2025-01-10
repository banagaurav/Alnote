using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Code.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingAndViewsToPdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Pdfs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Pdfs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadedAt",
                table: "Pdfs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Pdfs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Pdfs",
                columns: new[] { "Id", "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UserId", "Views" },
                values: new object[,]
                {
                    { 1, "Digital Logic", 4.5f, "/Images/thumbnail1.jpg", new DateTime(2025, 1, 11, 1, 46, 41, 889, DateTimeKind.Local).AddTicks(1527), 1, 1000 },
                    { 2, "Data Structures", 4.7f, "/Images/thumbnail2.jpg", new DateTime(2025, 1, 11, 1, 46, 41, 890, DateTimeKind.Local).AddTicks(1985), 2, 500 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 1, 46, 41, 890, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 1, 46, 41, 890, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 1, 46, 41, 890, DateTimeKind.Local).AddTicks(9356));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 1, 46, 41, 890, DateTimeKind.Local).AddTicks(9358));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Pdfs");

            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Pdfs");

            migrationBuilder.DropColumn(
                name: "UploadedAt",
                table: "Pdfs");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Pdfs");

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
    }
}
