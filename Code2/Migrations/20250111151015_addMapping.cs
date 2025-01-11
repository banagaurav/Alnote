using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class addMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Universities_UniversityId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UniversityId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 11, 20, 55, 14, 950, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 11, 20, 55, 14, 951, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniversityId1" },
                values: new object[] { new DateTime(2025, 1, 11, 15, 10, 14, 952, DateTimeKind.Utc).AddTicks(3301), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniversityId1" },
                values: new object[] { new DateTime(2025, 1, 11, 15, 10, 14, 952, DateTimeKind.Utc).AddTicks(3544), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniversityId1" },
                values: new object[] { new DateTime(2025, 1, 11, 15, 10, 14, 952, DateTimeKind.Utc).AddTicks(3576), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UniversityId1" },
                values: new object[] { new DateTime(2025, 1, 11, 15, 10, 14, 952, DateTimeKind.Utc).AddTicks(3578), null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversityId1",
                table: "Users",
                column: "UniversityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Universities_UniversityId",
                table: "Users",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Universities_UniversityId1",
                table: "Users",
                column: "UniversityId1",
                principalTable: "Universities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Universities_UniversityId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Universities_UniversityId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UniversityId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UniversityId1",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 11, 19, 0, 32, 317, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "Pdfs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadedAt",
                value: new DateTime(2025, 1, 11, 19, 0, 32, 318, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 13, 15, 32, 319, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 13, 15, 32, 319, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 13, 15, 32, 319, DateTimeKind.Utc).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 13, 15, 32, 319, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Universities_UniversityId",
                table: "Users",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");
        }
    }
}
