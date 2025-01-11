using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class correctAcademic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pdfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdfTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ThumbnailPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdfs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pdfs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Academics_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Universities",
                columns: new[] { "Id", "UniversityName" },
                values: new object[,]
                {
                    { 1, "TU" },
                    { 2, "PU" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 18, 15, 24, 383, DateTimeKind.Local).AddTicks(5259), "admin@example.com", "Admin@123", "Admin", "admin" },
                    { 2, new DateTime(2025, 1, 11, 18, 15, 24, 383, DateTimeKind.Local).AddTicks(5478), "client1@example.com", "Client1@123", "Client", "client1" },
                    { 3, new DateTime(2025, 1, 11, 18, 15, 24, 383, DateTimeKind.Local).AddTicks(5480), "client2@example.com", "Client2@123", "Client", "client2" },
                    { 4, new DateTime(2025, 1, 11, 18, 15, 24, 383, DateTimeKind.Local).AddTicks(5482), "client3@example.com", "Client3@123", "Client", "client3" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "FacultyName", "UniversityId" },
                values: new object[,]
                {
                    { 1, "Faculty of Humanities and Social Sciences", 1 },
                    { 2, "Faculty of Science", 1 },
                    { 3, "Faculty of Management", 1 },
                    { 4, "Faculty of Education", 1 },
                    { 5, "Faculty of Law", 1 },
                    { 6, "Faculty of Fine Arts", 1 },
                    { 7, "Faculty of Engineering", 1 },
                    { 8, "Faculty of Ayurveda and Alternative Medicine", 1 },
                    { 9, "Faculty of Agriculture", 1 },
                    { 10, "Faculty of Health Sciences", 1 },
                    { 11, "Faculty of Humanities and Social Sciences", 2 },
                    { 12, "Faculty of Science", 2 },
                    { 13, "Faculty of Management", 2 },
                    { 14, "Faculty of Education", 2 },
                    { 15, "Faculty of Law", 2 },
                    { 16, "Faculty of Fine Arts", 2 },
                    { 17, "Faculty of Engineering", 2 },
                    { 18, "Faculty of Ayurveda and Alternative Medicine", 2 },
                    { 19, "Faculty of Agriculture", 2 },
                    { 20, "Faculty of Health Sciences", 2 }
                });

            migrationBuilder.InsertData(
                table: "Pdfs",
                columns: new[] { "Id", "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "UserId", "Views" },
                values: new object[,]
                {
                    { 1, "Digital Logic", 4.5f, "/Images/thumbnail1.jpg", new DateTime(2025, 1, 11, 18, 15, 24, 381, DateTimeKind.Local).AddTicks(8637), 1, 1000 },
                    { 2, "Data Structures", 4.7f, "/Images/thumbnail2.jpg", new DateTime(2025, 1, 11, 18, 15, 24, 382, DateTimeKind.Local).AddTicks(8683), 2, 500 }
                });

            migrationBuilder.InsertData(
                table: "Academics",
                columns: new[] { "Id", "FacultyId", "ProgramName" },
                values: new object[,]
                {
                    { 1, 1, "BSc allbiology" },
                    { 2, 1, "BSc Microbiology" },
                    { 3, 1, "BSc Physics" },
                    { 4, 1, "BSc Chemistry" },
                    { 5, 1, "BSc Mathematics" },
                    { 6, 1, "BSc Environmental Science" },
                    { 7, 2, "BBA" },
                    { 8, 2, "MBA" },
                    { 9, 2, "BBS" },
                    { 10, 2, "MBS" },
                    { 11, 2, "BIM" },
                    { 12, 3, "BA Sociology" },
                    { 13, 3, "BA English" },
                    { 14, 3, "BA Political Science" },
                    { 15, 3, "BA Economics" },
                    { 16, 3, "MA Sociology" },
                    { 17, 4, "BSc CSIT" },
                    { 18, 4, "BSc Microbiology" },
                    { 19, 4, "BSc Environmental Science" },
                    { 20, 5, "BBA" },
                    { 21, 5, "MBA" },
                    { 22, 6, "BA English" },
                    { 23, 6, "BA Sociology" },
                    { 24, 7, "BEng Computer Engineering" },
                    { 25, 7, "BEng Civil Engineering" },
                    { 26, 7, "BEng Electrical Engineering" },
                    { 27, 7, "BEng Electronics and Communication Engineering" },
                    { 28, 8, "LLB" },
                    { 29, 9, "BEd" },
                    { 30, 9, "MEd" },
                    { 31, 10, "BFA" },
                    { 32, 11, "BSc Agriculture" },
                    { 33, 12, "BSc Nursing" },
                    { 34, 12, "BPH" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academics_FacultyId",
                table: "Academics",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfAcademicPrograms_AcademicProgramId",
                table: "PdfAcademicPrograms",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Pdfs_UserId",
                table: "Pdfs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfAcademicPrograms");

            migrationBuilder.DropTable(
                name: "Academics");

            migrationBuilder.DropTable(
                name: "Pdfs");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
