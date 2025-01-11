using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class deletePDfAcademic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfAcademicPrograms");

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 11, 18, 25, 28, 986, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 11, 18, 25, 28, 987, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 25, 28, 988, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 25, 28, 988, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 25, 28, 988, DateTimeKind.Local).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 25, 28, 988, DateTimeKind.Local).AddTicks(251));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 11, 18, 15, 24, 381, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 11, 18, 15, 24, 382, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 15, 24, 383, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 15, 24, 383, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 15, 24, 383, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 11, 18, 15, 24, 383, DateTimeKind.Local).AddTicks(5482));

            migrationBuilder.CreateIndex(
                name: "IX_PdfAcademicPrograms_AcademicProgramId",
                table: "PdfAcademicPrograms",
                column: "AcademicProgramId");
        }
    }
}
