using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Code2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pdfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdfTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ThumbnailPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdfs", x => x.Id);
                });

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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentSchoolOrCollege = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UniversityId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Universities_UniversityId1",
                        column: x => x.UniversityId1,
                        principalTable: "Universities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Academics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NoOfYears = table.Column<int>(type: "int", nullable: false),
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
                name: "PdfUsers",
                columns: table => new
                {
                    PdfId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfUsers", x => new { x.PdfId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PdfUsers_Pdfs_PdfId",
                        column: x => x.PdfId,
                        principalTable: "Pdfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PdfUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Academics_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "Academics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PdfSubjects",
                columns: table => new
                {
                    PdfId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfSubjects", x => new { x.PdfId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_PdfSubjects_Pdfs_PdfId",
                        column: x => x.PdfId,
                        principalTable: "Pdfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PdfSubjects_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pdfs",
                columns: new[] { "Id", "PdfTitle", "Rating", "ThumbnailPath", "UploadedAt", "Views" },
                values: new object[,]
                {
                    { 1, "BSc CSIT Course Material 1", 4.5f, "path/to/thumbnail1.jpg", new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2055), 100 },
                    { 2, "BSc Microbiology Course Material 1", 4f, "path/to/thumbnail2.jpg", new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2274), 200 },
                    { 3, "BBA and MBA Case Studies", 4.8f, "path/to/thumbnail3.jpg", new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2275), 150 },
                    { 4, "BBA and BIM Overview", 4.2f, "path/to/thumbnail4.jpg", new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2277), 50 },
                    { 5, "BSc Agriculture and BSc Nursing Guide", 4.1f, "path/to/thumbnail5.jpg", new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(2278), 250 }
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
                columns: new[] { "UserId", "CreatedDate", "CurrentSchoolOrCollege", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UniversityId", "UniversityId1", "Username" },
                values: new object[] { 3, new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(5210), "PQR Institute", new DateTime(1988, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "michaelj@example.com", "Michael", "Johnson", "password789", "555-123-9876", "Client", null, null, "michaeljohnson" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "FacultyName", "UniversityId" },
                values: new object[,]
                {
                    { 1, "Faculty of Humanities", 1 },
                    { 2, "Faculty of Science", 1 },
                    { 3, "Faculty of Management", 1 },
                    { 4, "Faculty of Law", 1 },
                    { 5, "Faculty of Education", 1 },
                    { 6, "Faculty of Engineering", 2 },
                    { 7, "Faculty of Science", 2 },
                    { 8, "Faculty of Management", 2 },
                    { 9, "Faculty of Law", 2 },
                    { 10, "Faculty of Fine Arts", 2 }
                });

            migrationBuilder.InsertData(
                table: "PdfUsers",
                columns: new[] { "PdfId", "UserId" },
                values: new object[] { 4, 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "CurrentSchoolOrCollege", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UniversityId", "UniversityId1", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(5017), "XYZ College", new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", "John", "Doe", "password123", "123-456-7890", "Admin", 1, null, "johndoe" },
                    { 2, new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(5208), "ABC University", new DateTime(1992, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "janesmith@example.com", "Jane", "Smith", "password456", "987-654-3210", "Client", 1, null, "janesmith" },
                    { 4, new DateTime(2025, 1, 13, 11, 7, 0, 514, DateTimeKind.Utc).AddTicks(5212), "LMN College", new DateTime(1995, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emilydavis@example.com", "Emily", "Davis", "password101", "123-789-4560", "Client", 2, null, "emilydavis" }
                });

            migrationBuilder.InsertData(
                table: "Academics",
                columns: new[] { "Id", "FacultyId", "NoOfYears", "ProgramName", "Type" },
                values: new object[,]
                {
                    { 1, 1, 3, "BA English", 0 },
                    { 2, 1, 3, "BA Sociology", 0 },
                    { 3, 2, 4, "BSc Computer Science", 1 },
                    { 4, 2, 4, "BSc Microbiology", 1 },
                    { 5, 3, 4, "BBA", 1 },
                    { 6, 3, 2, "MBA", 1 },
                    { 7, 4, 5, "LLB", 0 },
                    { 8, 4, 2, "LLM", 0 },
                    { 9, 5, 2, "BEd", 0 },
                    { 10, 5, 2, "MEd", 0 },
                    { 11, 6, 4, "BEng Civil Engineering", 1 },
                    { 12, 6, 4, "BEng Electrical Engineering", 1 },
                    { 13, 7, 3, "BSc Chemistry", 0 },
                    { 14, 7, 3, "BSc Physics", 0 },
                    { 15, 8, 4, "BBA", 1 },
                    { 16, 8, 2, "MBA", 1 },
                    { 17, 9, 5, "LLB", 0 },
                    { 18, 9, 2, "LLM", 0 },
                    { 19, 10, 4, "BFA", 0 }
                });

            migrationBuilder.InsertData(
                table: "PdfUsers",
                columns: new[] { "PdfId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "AcademicProgramId", "SubjectCode", "SubjectName" },
                values: new object[,]
                {
                    { 1, 3, "CSIT101", "Mathematics I" },
                    { 2, 3, "CSIT102", "Physics I" },
                    { 3, 3, "CSIT103", "Computer Science Basics" },
                    { 4, 18, "MICRO101", "Microbiology Fundamentals" },
                    { 5, 18, "MICRO102", "Organic Chemistry" },
                    { 6, 6, "ENV101", "Environmental Science Basics" },
                    { 7, 6, "ENV102", "Biodiversity" },
                    { 8, 7, "BBA101", "Principles of Management" },
                    { 9, 7, "BBA102", "Business Statistics" },
                    { 10, 8, "MBA101", "Advanced Accounting" },
                    { 11, 8, "MBA102", "Marketing Management" },
                    { 12, 11, "BIM101", "Database Management Systems" },
                    { 13, 11, "BIM102", "Software Engineering" },
                    { 14, 3, "AGRI101", "Agriculture Economics" },
                    { 15, 3, "AGRI102", "Crop Production" },
                    { 16, 3, "NUR101", "Anatomy and Physiology" },
                    { 17, 3, "NUR102", "Community Health Nursing" },
                    { 18, 7, "BBA103", "Human Resource Management" },
                    { 19, 8, "MBA103", "Business Ethics" },
                    { 20, 17, "CSIT104", "Data Structures" }
                });

            migrationBuilder.InsertData(
                table: "PdfSubjects",
                columns: new[] { "PdfId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
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
                name: "IX_PdfSubjects_SubjectId",
                table: "PdfSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfUsers_UserId",
                table: "PdfUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_AcademicProgramId",
                table: "Subject",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversityId",
                table: "Users",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversityId1",
                table: "Users",
                column: "UniversityId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfSubjects");

            migrationBuilder.DropTable(
                name: "PdfUsers");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Pdfs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Academics");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
