using Microsoft.EntityFrameworkCore;
using Code2.Models;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    // Other DbSets (e.g., Pdfs, Faculties)
    public DbSet<Pdf> Pdfs { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<AcademicProgram> Academics { get; set; }
    public DbSet<PdfAcademicProgram> PdfAcademicPrograms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the one-to-many relationship between User and Pdf
        modelBuilder.Entity<Pdf>()
            .HasOne(p => p.User)
            .WithMany(u => u.UploadedPdfs)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure many-to-many relationship between Pdf and AcademicProgram
        modelBuilder.Entity<PdfAcademicProgram>()
            .HasKey(pap => new { pap.PdfId, pap.AcademicProgramId }); // Composite primary key

        modelBuilder.Entity<PdfAcademicProgram>()
            .HasOne(pap => pap.Pdf)
            .WithMany(p => p.PdfAcademicPrograms)
            .HasForeignKey(pap => pap.PdfId);

        modelBuilder.Entity<PdfAcademicProgram>()
            .HasOne(pap => pap.AcademicProgram)
            .WithMany(ap => ap.PdfAcademicPrograms)
            .HasForeignKey(pap => pap.AcademicProgramId);

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

        // Seed data for Pdf
        modelBuilder.Entity<Pdf>().HasData(
            new Pdf
            {
                Id = 1,  // Manually assigning the Id
                PdfTitle = "Digital Logic",
                UserId = 1,  // Assuming a user with ID 1 exists
                Rating = 4.5f,
                Views = 1000,
                UploadedAt = DateTime.Now,
                ThumbnailPath = "/Images/thumbnail1.jpg" // Add a path for the thumbnail
            },
            new Pdf
            {
                Id = 2,  // Manually assigning the Id
                PdfTitle = "Data Structures",
                UserId = 2,
                Rating = 4.7f,
                Views = 500,
                UploadedAt = DateTime.Now,
                ThumbnailPath = "/Images/thumbnail2.jpg" // Add a path for the thumbnail
            }
        );
        // Seed data for Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                UserName = "admin",
                Email = "admin@example.com",
                Password = "Admin@123", // You should hash the password in production
                Role = "Admin",
                CreatedAt = DateTime.Now
            },
            new User
            {
                UserId = 2,
                UserName = "client1",
                Email = "client1@example.com",
                Password = "Client1@123", // You should hash the password in production
                Role = "Client",
                CreatedAt = DateTime.Now
            },
            new User
            {
                UserId = 3,
                UserName = "client2",
                Email = "client2@example.com",
                Password = "Client2@123", // You should hash the password in production
                Role = "Client",
                CreatedAt = DateTime.Now
            },
            new User
            {
                UserId = 4,
                UserName = "client3",
                Email = "client3@example.com",
                Password = "Client3@123", // You should hash the password in production
                Role = "Client",
                CreatedAt = DateTime.Now
            }
        );

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
