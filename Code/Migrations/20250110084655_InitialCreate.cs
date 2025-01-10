using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Code.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "UniversityName" },
                values: new object[,]
                {
                    { 1, "TU" },
                    { 2, "PU" }
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
                table: "Academics",
                columns: new[] { "Id", "FacultyId", "ProgramName" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Academics");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
