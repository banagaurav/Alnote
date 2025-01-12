using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class seedpdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PdfTitle", "ThumbnailPath", "UploadedAt", "Views" },
                values: new object[] { "Introduction to C#", "/thumbnails/intro-csharp.jpg", new DateTime(2025, 1, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 123 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "Views" },
                values: new object[] { "Mastering ASP.NET", 4.8f, "/thumbnails/mastering-aspnet.jpg", new DateTime(2025, 1, 11, 8, 30, 0, 0, DateTimeKind.Unspecified), 89 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 6, 18, 27, 966, DateTimeKind.Utc).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 6, 18, 27, 966, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 6, 18, 27, 966, DateTimeKind.Utc).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 6, 18, 27, 966, DateTimeKind.Utc).AddTicks(1777));

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PdfTitle", "ThumbnailPath", "UploadedAt", "Views" },
                values: new object[] { "Digital Logic", "/Images/thumbnail1.jpg", new DateTime(2025, 1, 11, 20, 55, 14, 950, DateTimeKind.Local).AddTicks(3558), 1000 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "Views" },
                values: new object[] { "Data Structures", 4.7f, "/Images/thumbnail2.jpg", new DateTime(2025, 1, 11, 20, 55, 14, 951, DateTimeKind.Local).AddTicks(4867), 500 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 15, 10, 14, 952, DateTimeKind.Utc).AddTicks(3301));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 15, 10, 14, 952, DateTimeKind.Utc).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 15, 10, 14, 952, DateTimeKind.Utc).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 15, 10, 14, 952, DateTimeKind.Utc).AddTicks(3578));

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
