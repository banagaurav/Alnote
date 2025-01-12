using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class seedPdfAcademicProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "Pdfs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PdfAcademicPrograms",
                columns: table => new
                {
                    PdfId = table.Column<int>(type: "int", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfAcademicPrograms", x => new { x.PdfId, x.AcademicProgramId });
                    table.ForeignKey(
                        name: "FK_PdfAcademicPrograms_Academics_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "Academics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PdfAcademicPrograms_Pdfs_PdfId",
                        column: x => x.PdfId,
                        principalTable: "Pdfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PdfAcademicPrograms",
                columns: new[] { "AcademicProgramId", "PdfId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PdfTitle", "ThumbnailPath", "UploadedAt", "UploadedBy", "Views" },
                values: new object[] { "Introduction to Biology", "/thumbnails/biology.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2036), "John Doe", 1000 });

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[] { "Advanced Chemistry", 4f, "/thumbnails/chemistry.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2441), "John Doe", 1, 800 });

            migrationBuilder.InsertData(
                table: "Pdfs",
                columns: new[] { "Id", "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UploadedBy", "UserId", "Views" },
                values: new object[,]
                {
                    { 3, "Engineering Physics", 4.3f, "/thumbnails/physics.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2443), "John Doe", 1, 1200 },
                    { 4, "Computer Science Fundamentals", 4.6f, "/thumbnails/computerscience.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2445), "John Doe", 1, 1500 },
                    { 5, "Business Administration Concepts", 4.2f, "/thumbnails/business.png", new DateTime(2025, 1, 12, 14, 2, 54, 336, DateTimeKind.Utc).AddTicks(2448), "John Doe", 1, 950 }
                });

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

            migrationBuilder.InsertData(
                table: "PdfAcademicPrograms",
                columns: new[] { "AcademicProgramId", "PdfId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PdfAcademicPrograms_AcademicProgramId",
                table: "PdfAcademicPrograms",
                column: "AcademicProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfAcademicPrograms");

            migrationBuilder.DeleteData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "Pdfs");

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
                columns: new[] { "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UserId", "Views" },
                values: new object[] { "Mastering ASP.NET", 4.8f, "/thumbnails/mastering-aspnet.jpg", new DateTime(2025, 1, 11, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, 89 });

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
        }
    }
}
