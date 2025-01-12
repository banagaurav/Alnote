using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class seedPdfAcademicPrograms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "PdfAcademicPrograms",
                columns: new[] { "AcademicProgramId", "PdfId" },
                values: new object[,]
                {
                    { 17, 1 },
                    { 18, 1 },
                    { 6, 2 },
                    { 18, 2 },
                    { 7, 3 },
                    { 8, 3 },
                    { 7, 4 },
                    { 11, 4 },
                    { 32, 5 },
                    { 33, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PdfTitle", "ThumbnailPath", "UploadedAt", "Views" },
                values: new object[] { "BSc CSIT Course Material 1", "path/to/thumbnail1.jpg", new DateTime(2025, 1, 12, 14, 14, 6, 7, DateTimeKind.Utc).AddTicks(4391), 100 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PdfTitle", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "BSc Microbiology Course Material 1", "path/to/thumbnail2.jpg", new DateTime(2025, 1, 12, 14, 14, 6, 7, DateTimeKind.Utc).AddTicks(4905), "Jane Doe", 2, 200 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "BBA and MBA Case Studies", 4.8f, "path/to/thumbnail3.jpg", new DateTime(2025, 1, 12, 14, 14, 6, 7, DateTimeKind.Utc).AddTicks(4909), "Emily Smith", 3, 150 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "BBA and BIM Overview", 4.2f, "path/to/thumbnail4.jpg", new DateTime(2025, 1, 12, 14, 14, 6, 7, DateTimeKind.Utc).AddTicks(4911), "David Johnson", 4, 50 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "BSc Agriculture and BSc Nursing Guide", 4.1f, "path/to/thumbnail5.jpg", new DateTime(2025, 1, 12, 14, 14, 6, 7, DateTimeKind.Utc).AddTicks(4914), "Sarah Lee", 3, 250 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 14, 14, 6, 6, DateTimeKind.Utc).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 14, 14, 6, 6, DateTimeKind.Utc).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 14, 14, 6, 6, DateTimeKind.Utc).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 14, 14, 6, 6, DateTimeKind.Utc).AddTicks(4513));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 32, 5 });

            migrationBuilder.DeleteData(
                table: "PdfAcademicPrograms",
                keyColumns: new[] { "AcademicProgramId", "PdfId" },
                keyValues: new object[] { 33, 5 });

            migrationBuilder.InsertData(
                table: "PdfAcademicPrograms",
                columns: new[] { "AcademicProgramId", "PdfId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PdfTitle", "ThumbnailPath", "UploadedAt", "Views" },
                values: new object[] { "Introduction to Biology", "/thumbnails/biology.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2036), 1000 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PdfTitle", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "Advanced Chemistry", "/thumbnails/chemistry.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2441), "John Doe", 1, 800 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "Engineering Physics", 4.3f, "/thumbnails/physics.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2443), "John Doe", 1, 1200 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "Computer Science Fundamentals", 4.6f, "/thumbnails/computerscience.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2445), "John Doe", 1, 1500 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "Business Administration Concepts", 4.2f, "/thumbnails/business.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2448), "John Doe", 1, 950 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 14, 2, 54, 335, DateTimeKind.Utc).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 14, 2, 54, 335, DateTimeKind.Utc).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 14, 2, 54, 335, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 14, 2, 54, 335, DateTimeKind.Utc).AddTicks(2588));
        }
    }
}
