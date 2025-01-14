using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class PutSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PdfSubjects_Subject_SubjectId",
                table: "PdfSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Academics_AcademicProgramId",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_AcademicProgramId",
                table: "Subjects",
                newName: "IX_Subjects_AcademicProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PdfSubjects_Subjects_SubjectId",
                table: "PdfSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Academics_AcademicProgramId",
                table: "Subjects",
                column: "AcademicProgramId",
                principalTable: "Academics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PdfSubjects_Subjects_SubjectId",
                table: "PdfSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Academics_AcademicProgramId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_AcademicProgramId",
                table: "Subject",
                newName: "IX_Subject_AcademicProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 4,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 5,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(5212));

            migrationBuilder.AddForeignKey(
                name: "FK_PdfSubjects_Subject_SubjectId",
                table: "PdfSubjects",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Academics_AcademicProgramId",
                table: "Subject",
                column: "AcademicProgramId",
                principalTable: "Academics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
