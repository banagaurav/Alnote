using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "DateOfBirth");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrentSchoolOrCollege",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Users",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreatedDate", "CurrentSchoolOrCollege", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "UniversityId", "Username" },
                values: new object[] { new DateTime(2025, 1, 11, 13, 15, 32, 319, DateTimeKind.Utc).AddTicks(115), "XYZ College", new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", "John", "Doe", "password123", "123-456-7890", 1, "johndoe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "CurrentSchoolOrCollege", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "UniversityId", "Username" },
                values: new object[] { new DateTime(2025, 1, 11, 13, 15, 32, 319, DateTimeKind.Utc).AddTicks(311), "ABC University", new DateTime(1992, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "janesmith@example.com", "Jane", "Smith", "password456", "987-654-3210", 1, "janesmith" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "CurrentSchoolOrCollege", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "UniversityId", "Username" },
                values: new object[] { new DateTime(2025, 1, 11, 13, 15, 32, 319, DateTimeKind.Utc).AddTicks(314), "PQR Institute", new DateTime(1988, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "michaelj@example.com", "Michael", "Johnson", "password789", "555-123-9876", null, "michaeljohnson" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "CurrentSchoolOrCollege", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "UniversityId", "Username" },
                values: new object[] { new DateTime(2025, 1, 11, 13, 15, 32, 319, DateTimeKind.Utc).AddTicks(316), "LMN College", new DateTime(1995, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emilydavis@example.com", "Emily", "Davis", "password101", "123-789-4560", 2, "emilydavis" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversityId",
                table: "Users",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Universities_UniversityId",
                table: "Users",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Universities_UniversityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UniversityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentSchoolOrCollege",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                columns: new[] { "CreatedAt", "Email", "Password", "UserName" },
                values: new object[] { new DateTime(2025, 1, 11, 18, 25, 28, 988, DateTimeKind.Local).AddTicks(29), "admin@example.com", "Admin@123", "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "Password", "UserName" },
                values: new object[] { new DateTime(2025, 1, 11, 18, 25, 28, 988, DateTimeKind.Local).AddTicks(247), "client1@example.com", "Client1@123", "client1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Email", "Password", "UserName" },
                values: new object[] { new DateTime(2025, 1, 11, 18, 25, 28, 988, DateTimeKind.Local).AddTicks(249), "client2@example.com", "Client2@123", "client2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Email", "Password", "UserName" },
                values: new object[] { new DateTime(2025, 1, 11, 18, 25, 28, 988, DateTimeKind.Local).AddTicks(251), "client3@example.com", "Client3@123", "client3" });
        }
    }
}
