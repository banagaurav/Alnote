using Code.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Pdf> Pdfs { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<AcademicProgram> Academics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the one-to-many relationship between Faculty and University
        modelBuilder.Entity<Faculty>()
            .HasOne(f => f.University)
            .WithMany(u => u.Faculties)
            .HasForeignKey(f => f.UniversityId);

        // Define relationships Between AcadamicProgram and Faculty
        modelBuilder.Entity<AcademicProgram>()
            .HasOne(p => p.Faculty)
            .WithMany(f => f.AcademicPrograms)
            .HasForeignKey(p => p.FacultyId);

        // Seed data for University
        modelBuilder.Entity<University>().HasData(
            new University { Id = 1, UniversityName = "TU" },
            new University { Id = 2, UniversityName = "PU" }
        );

        // Seed data for Faculties of TU
        modelBuilder.Entity<Faculty>().HasData(
            // Faculties for TU
            new Faculty { Id = 1, FacultyName = "Faculty of Humanities and Social Sciences", UniversityId = 1 },
            new Faculty { Id = 2, FacultyName = "Faculty of Science", UniversityId = 1 },
            new Faculty { Id = 3, FacultyName = "Faculty of Management", UniversityId = 1 },
            new Faculty { Id = 4, FacultyName = "Faculty of Education", UniversityId = 1 },
            new Faculty { Id = 5, FacultyName = "Faculty of Law", UniversityId = 1 },
            new Faculty { Id = 6, FacultyName = "Faculty of Fine Arts", UniversityId = 1 },
            new Faculty { Id = 7, FacultyName = "Faculty of Engineering", UniversityId = 1 },
            new Faculty { Id = 8, FacultyName = "Faculty of Ayurveda and Alternative Medicine", UniversityId = 1 },
            new Faculty { Id = 9, FacultyName = "Faculty of Agriculture", UniversityId = 1 },
            new Faculty { Id = 10, FacultyName = "Faculty of Health Sciences", UniversityId = 1 },

            // Faculties for PU
            new Faculty { Id = 11, FacultyName = "Faculty of Humanities and Social Sciences", UniversityId = 2 },
            new Faculty { Id = 12, FacultyName = "Faculty of Science", UniversityId = 2 },
            new Faculty { Id = 13, FacultyName = "Faculty of Management", UniversityId = 2 },
            new Faculty { Id = 14, FacultyName = "Faculty of Education", UniversityId = 2 },
            new Faculty { Id = 15, FacultyName = "Faculty of Law", UniversityId = 2 },
            new Faculty { Id = 16, FacultyName = "Faculty of Fine Arts", UniversityId = 2 },
            new Faculty { Id = 17, FacultyName = "Faculty of Engineering", UniversityId = 2 },
            new Faculty { Id = 18, FacultyName = "Faculty of Ayurveda and Alternative Medicine", UniversityId = 2 },
            new Faculty { Id = 19, FacultyName = "Faculty of Agriculture", UniversityId = 2 },
            new Faculty { Id = 20, FacultyName = "Faculty of Health Sciences", UniversityId = 2 }
        );

        modelBuilder.Entity<AcademicProgram>().HasData(
            // Programs for TU - Faculty of Science
            new AcademicProgram { Id = 2, ProgramName = "BSc Microbiology", FacultyId = 1 },
            new AcademicProgram { Id = 3, ProgramName = "BSc Physics", FacultyId = 1 },
            new AcademicProgram { Id = 4, ProgramName = "BSc Chemistry", FacultyId = 1 },
            new AcademicProgram { Id = 5, ProgramName = "BSc Mathematics", FacultyId = 1 },
            new AcademicProgram { Id = 6, ProgramName = "BSc Environmental Science", FacultyId = 1 },

            // Programs for TU - Faculty of Management
            new AcademicProgram { Id = 7, ProgramName = "BBA", FacultyId = 2 },
            new AcademicProgram { Id = 8, ProgramName = "MBA", FacultyId = 2 },
            new AcademicProgram { Id = 9, ProgramName = "BBS", FacultyId = 2 },
            new AcademicProgram { Id = 10, ProgramName = "MBS", FacultyId = 2 },
            new AcademicProgram { Id = 11, ProgramName = "BIM", FacultyId = 2 },

            // Programs for TU - Faculty of Humanities and Social Sciences
            new AcademicProgram { Id = 12, ProgramName = "BA Sociology", FacultyId = 3 },
            new AcademicProgram { Id = 13, ProgramName = "BA English", FacultyId = 3 },
            new AcademicProgram { Id = 14, ProgramName = "BA Political Science", FacultyId = 3 },
            new AcademicProgram { Id = 15, ProgramName = "BA Economics", FacultyId = 3 },
            new AcademicProgram { Id = 16, ProgramName = "MA Sociology", FacultyId = 3 },

            // Programs for PU - Faculty of Science
            new AcademicProgram { Id = 17, ProgramName = "BSc CSIT", FacultyId = 4 },
            new AcademicProgram { Id = 18, ProgramName = "BSc Microbiology", FacultyId = 4 },
            new AcademicProgram { Id = 19, ProgramName = "BSc Environmental Science", FacultyId = 4 },

            // Programs for PU - Faculty of Management
            new AcademicProgram { Id = 20, ProgramName = "BBA", FacultyId = 5 },
            new AcademicProgram { Id = 21, ProgramName = "MBA", FacultyId = 5 },

            // Programs for PU - Faculty of Humanities and Social Sciences
            new AcademicProgram { Id = 22, ProgramName = "BA English", FacultyId = 6 },
            new AcademicProgram { Id = 23, ProgramName = "BA Sociology", FacultyId = 6 },

            // Programs for PU - Faculty of Engineering
            new AcademicProgram { Id = 24, ProgramName = "BEng Computer Engineering", FacultyId = 7 },
            new AcademicProgram { Id = 25, ProgramName = "BEng Civil Engineering", FacultyId = 7 },
            new AcademicProgram { Id = 26, ProgramName = "BEng Electrical Engineering", FacultyId = 7 },
            new AcademicProgram { Id = 27, ProgramName = "BEng Electronics and Communication Engineering", FacultyId = 7 },

            // Programs for PU - Faculty of Law
            new AcademicProgram { Id = 28, ProgramName = "LLB", FacultyId = 8 },

            // Programs for PU - Faculty of Education
            new AcademicProgram { Id = 29, ProgramName = "BEd", FacultyId = 9 },
            new AcademicProgram { Id = 30, ProgramName = "MEd", FacultyId = 9 },

            // Programs for PU - Faculty of Fine Arts
            new AcademicProgram { Id = 31, ProgramName = "BFA", FacultyId = 10 },

            // Programs for PU - Faculty of Agriculture
            new AcademicProgram { Id = 32, ProgramName = "BSc Agriculture", FacultyId = 11 },

            // Programs for PU - Faculty of Health Sciences
            new AcademicProgram { Id = 33, ProgramName = "BSc Nursing", FacultyId = 12 },
            new AcademicProgram { Id = 34, ProgramName = "BPH", FacultyId = 12 }
        );

    }
}
