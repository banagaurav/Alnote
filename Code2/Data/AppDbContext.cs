using Microsoft.EntityFrameworkCore;
using Code2.Models;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    // Other DbSets (e.g., Pdfs, Faculties)
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<AcademicProgram> Academics { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Pdf> Pdfs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PdfSubject> PdfSubjects { get; set; }
    public DbSet<PdfUser> PdfUsers { get; set; }

    //for createdDate
    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is User && e.State == EntityState.Added);

        foreach (var entry in entries)
        {
            ((User)entry.Entity).CreatedDate = DateTime.UtcNow;
        }

        return base.SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring PdfUser as a many-to-many relationship
        modelBuilder.Entity<PdfUser>()
            .HasKey(pu => new { pu.PdfId, pu.UserId }); // Composite primary key

        modelBuilder.Entity<PdfUser>()
            .HasOne(pu => pu.Pdf)
            .WithMany(p => p.PdfUsers)
            .HasForeignKey(pu => pu.PdfId);

        modelBuilder.Entity<PdfUser>()
            .HasOne(pu => pu.User)
            .WithMany(u => u.PdfUsers)
            .HasForeignKey(pu => pu.UserId);

        // Configure the many-to-many relationship
        modelBuilder.Entity<PdfSubject>()
        .HasKey(ps => new { ps.PdfId, ps.SubjectId });  // Composite primary key

        modelBuilder.Entity<PdfSubject>()
            .HasOne(ps => ps.Pdf)
            .WithMany(p => p.PdfSubjects)
            .HasForeignKey(ps => ps.PdfId);

        modelBuilder.Entity<PdfSubject>()
            .HasOne(ps => ps.Subject)
            .WithMany(s => s.PdfSubjects)
            .HasForeignKey(ps => ps.SubjectId);

        // Configure the one-to-many relationship between Faculty and University
        modelBuilder.Entity<Faculty>()
            .HasOne(f => f.University)
            .WithMany(u => u.Faculties)
            .HasForeignKey(f => f.UniversityId)
            .OnDelete(DeleteBehavior.Restrict);

        // Define relationships Between AcadamicProgram and Faculty
        modelBuilder.Entity<AcademicProgram>()
            .HasOne(p => p.Faculty)
            .WithMany(f => f.AcademicPrograms)
            .HasForeignKey(p => p.FacultyId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.University)
            .WithMany()
            .HasForeignKey(u => u.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();

        modelBuilder.Entity<Subject>()
            .HasOne(s => s.AcademicProgram)        // Subject has one AcademicProgram
            .WithMany(ap => ap.Subjects)           // AcademicProgram has many Subjects
            .HasForeignKey(s => s.AcademicProgramId) // Foreign key in Subject
            .OnDelete(DeleteBehavior.Restrict);    // Restrict delete when AcademicProgram is delete

        // Seed data for University
        modelBuilder.Entity<University>().HasData(
            new University { Id = 1, UniversityName = "TU" },
            new University { Id = 2, UniversityName = "PU" }
        );

        // Seed data for Faculties of TU
        modelBuilder.Entity<Faculty>().HasData(
            // Faculties for TU
            new Faculty { Id = 1, FacultyName = "Faculty of Humanities", UniversityId = 1 },
            new Faculty { Id = 2, FacultyName = "Faculty of Science", UniversityId = 1 },
            new Faculty { Id = 3, FacultyName = "Faculty of Management", UniversityId = 1 },
            new Faculty { Id = 4, FacultyName = "Faculty of Law", UniversityId = 1 },
            new Faculty { Id = 5, FacultyName = "Faculty of Education", UniversityId = 1 },

            // Faculties for PU
            new Faculty { Id = 6, FacultyName = "Faculty of Engineering", UniversityId = 2 },
            new Faculty { Id = 7, FacultyName = "Faculty of Science", UniversityId = 2 },
            new Faculty { Id = 8, FacultyName = "Faculty of Management", UniversityId = 2 },
            new Faculty { Id = 9, FacultyName = "Faculty of Law", UniversityId = 2 },
            new Faculty { Id = 10, FacultyName = "Faculty of Fine Arts", UniversityId = 2 }
        );

        modelBuilder.Entity<AcademicProgram>().HasData(
            // Academic Programs for Faculty of Humanities (TU)
            new AcademicProgram { Id = 1, ProgramName = "BA English", Type = 0, NoOfYears = 3, FacultyId = 1 },
            new AcademicProgram { Id = 2, ProgramName = "BA Sociology", Type = 0, NoOfYears = 3, FacultyId = 1 },

            // Academic Programs for Faculty of Science (TU)
            new AcademicProgram { Id = 3, ProgramName = "BSc Computer Science", Type = 1, NoOfYears = 4, FacultyId = 2 },
            new AcademicProgram { Id = 4, ProgramName = "BSc Microbiology", Type = 1, NoOfYears = 4, FacultyId = 2 },

            // Academic Programs for Faculty of Management (TU)
            new AcademicProgram { Id = 5, ProgramName = "BBA", Type = 1, NoOfYears = 4, FacultyId = 3 },
            new AcademicProgram { Id = 6, ProgramName = "MBA", Type = 1, NoOfYears = 2, FacultyId = 3 },

            // Academic Programs for Faculty of Law (TU)
            new AcademicProgram { Id = 7, ProgramName = "LLB", Type = 0, NoOfYears = 5, FacultyId = 4 },
            new AcademicProgram { Id = 8, ProgramName = "LLM", Type = 0, NoOfYears = 2, FacultyId = 4 },

            // Academic Programs for Faculty of Education (TU)
            new AcademicProgram { Id = 9, ProgramName = "BEd", Type = 0, NoOfYears = 2, FacultyId = 5 },
            new AcademicProgram { Id = 10, ProgramName = "MEd", Type = 0, NoOfYears = 2, FacultyId = 5 },

            // Academic Programs for Faculty of Engineering (PU)
            new AcademicProgram { Id = 11, ProgramName = "BEng Civil Engineering", Type = 1, NoOfYears = 4, FacultyId = 6 },
            new AcademicProgram { Id = 12, ProgramName = "BEng Electrical Engineering", Type = 1, NoOfYears = 4, FacultyId = 6 },

            // Academic Programs for Faculty of Science (PU)
            new AcademicProgram { Id = 13, ProgramName = "BSc Chemistry", Type = 0, NoOfYears = 3, FacultyId = 7 },
            new AcademicProgram { Id = 14, ProgramName = "BSc Physics", Type = 0, NoOfYears = 3, FacultyId = 7 },

            // Academic Programs for Faculty of Management (PU)
            new AcademicProgram { Id = 15, ProgramName = "BBA", Type = 1, NoOfYears = 4, FacultyId = 8 },
            new AcademicProgram { Id = 16, ProgramName = "MBA", Type = 1, NoOfYears = 2, FacultyId = 8 },

            // Academic Programs for Faculty of Law (PU)
            new AcademicProgram { Id = 17, ProgramName = "LLB", Type = 0, NoOfYears = 5, FacultyId = 9 },
            new AcademicProgram { Id = 18, ProgramName = "LLM", Type = 0, NoOfYears = 2, FacultyId = 9 },

            // Academic Programs for Faculty of Fine Arts (PU)
            new AcademicProgram { Id = 19, ProgramName = "BFA", Type = 0, NoOfYears = 4, FacultyId = 10 }
        );


        modelBuilder.Entity<Subject>().HasData(
            new Subject { Id = 1, SubjectName = "Mathematics I", SubjectCode = "CSIT101", AcademicProgramId = 3 }, // BSc CSIT
            new Subject { Id = 2, SubjectName = "Physics I", SubjectCode = "CSIT102", AcademicProgramId = 3 },     // BSc CSIT
            new Subject { Id = 3, SubjectName = "Computer Science Basics", SubjectCode = "CSIT103", AcademicProgramId = 3 }, // BSc CSIT
            new Subject { Id = 4, SubjectName = "Microbiology Fundamentals", SubjectCode = "MICRO101", AcademicProgramId = 18 }, // BSc Microbiology
            new Subject { Id = 5, SubjectName = "Organic Chemistry", SubjectCode = "MICRO102", AcademicProgramId = 18 },        // BSc Microbiology
            new Subject { Id = 6, SubjectName = "Environmental Science Basics", SubjectCode = "ENV101", AcademicProgramId = 6 }, // BSc Environmental Science
            new Subject { Id = 7, SubjectName = "Biodiversity", SubjectCode = "ENV102", AcademicProgramId = 6 },                // BSc Environmental Science
            new Subject { Id = 8, SubjectName = "Principles of Management", SubjectCode = "BBA101", AcademicProgramId = 7 },    // BBA
            new Subject { Id = 9, SubjectName = "Business Statistics", SubjectCode = "BBA102", AcademicProgramId = 7 },         // BBA
            new Subject { Id = 10, SubjectName = "Advanced Accounting", SubjectCode = "MBA101", AcademicProgramId = 8 },        // MBA
            new Subject { Id = 11, SubjectName = "Marketing Management", SubjectCode = "MBA102", AcademicProgramId = 8 },       // MBA
            new Subject { Id = 12, SubjectName = "Database Management Systems", SubjectCode = "BIM101", AcademicProgramId = 11 }, // BIM
            new Subject { Id = 13, SubjectName = "Software Engineering", SubjectCode = "BIM102", AcademicProgramId = 11 },       // BIM
            new Subject { Id = 14, SubjectName = "Agriculture Economics", SubjectCode = "AGRI101", AcademicProgramId = 3 },      // BSc Agriculture
            new Subject { Id = 15, SubjectName = "Crop Production", SubjectCode = "AGRI102", AcademicProgramId = 3 },            // BSc Agriculture
            new Subject { Id = 16, SubjectName = "Anatomy and Physiology", SubjectCode = "NUR101", AcademicProgramId = 3 },     // BSc Nursing
            new Subject { Id = 17, SubjectName = "Community Health Nursing", SubjectCode = "NUR102", AcademicProgramId = 3 },   // BSc Nursing
            new Subject { Id = 18, SubjectName = "Human Resource Management", SubjectCode = "BBA103", AcademicProgramId = 7 },   // BBA
            new Subject { Id = 19, SubjectName = "Business Ethics", SubjectCode = "MBA103", AcademicProgramId = 8 },             // MBA
            new Subject { Id = 20, SubjectName = "Data Structures", SubjectCode = "CSIT104", AcademicProgramId = 17 }            // BSc CSIT
        );


        modelBuilder.Entity<Pdf>().HasData(
                // PDF 1 for BSc CSIT and BSc Microbiology
                new Pdf
                {
                    Id = 1,
                    PdfTitle = "BSc CSIT Course Material 1",
                    ThumbnailPath = "path/to/thumbnail1.jpg",
                    Rating = 4.5f,
                    Views = 100,
                    UploadedAt = DateTime.UtcNow,
                },
                // PDF 2 for BSc Microbiology and BSc Environmental Science
                new Pdf
                {
                    Id = 2,
                    PdfTitle = "BSc Microbiology Course Material 1",
                    ThumbnailPath = "path/to/thumbnail2.jpg",
                    Rating = 4.0f,
                    Views = 200,
                    UploadedAt = DateTime.UtcNow,
                },
                // PDF 3 for BBA and MBA
                new Pdf
                {
                    Id = 3,
                    PdfTitle = "BBA and MBA Case Studies",
                    ThumbnailPath = "path/to/thumbnail3.jpg",
                    Rating = 4.8f,
                    Views = 150,
                    UploadedAt = DateTime.UtcNow,
                },
                // PDF 4 for BBA and BIM
                new Pdf
                {
                    Id = 4,
                    PdfTitle = "BBA and BIM Overview",
                    ThumbnailPath = "path/to/thumbnail4.jpg",
                    Rating = 4.2f,
                    Views = 50,
                    UploadedAt = DateTime.UtcNow,
                },
                // PDF 5 for BSc Agriculture and BSc Nursing
                new Pdf
                {
                    Id = 5,
                    PdfTitle = "BSc Agriculture and BSc Nursing Guide",
                    ThumbnailPath = "path/to/thumbnail5.jpg",
                    Rating = 4.1f,
                    Views = 250,
                    UploadedAt = DateTime.UtcNow,
                }
        );


        // Seed Users data
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 5, 12),
                PhoneNumber = "123-456-7890",
                Email = "johndoe@example.com",
                CurrentSchoolOrCollege = "XYZ College",
                UniversityId = 1, // assuming this university exists
                Password = "password123",
                Username = "johndoe",
                Role = "Admin",
                CreatedDate = DateTime.UtcNow
            },
            new User
            {
                UserId = 2,
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(1992, 7, 24),
                PhoneNumber = "987-654-3210",
                Email = "janesmith@example.com",
                CurrentSchoolOrCollege = "ABC University",
                UniversityId = 1, // assuming this university exists
                Password = "password456",
                Username = "janesmith",
                Role = "Client",
                CreatedDate = DateTime.UtcNow
            },
            new User
            {
                UserId = 3,
                FirstName = "Michael",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1988, 11, 30),
                PhoneNumber = "555-123-9876",
                Email = "michaelj@example.com",
                CurrentSchoolOrCollege = "PQR Institute",
                UniversityId = null, // Null means no university associated
                Password = "password789",
                Username = "michaeljohnson",
                Role = "Client",
                CreatedDate = DateTime.UtcNow
            },
            new User
            {
                UserId = 4,
                FirstName = "Emily",
                LastName = "Davis",
                DateOfBirth = new DateTime(1995, 3, 5),
                PhoneNumber = "123-789-4560",
                Email = "emilydavis@example.com",
                CurrentSchoolOrCollege = "LMN College",
                UniversityId = 2, // assuming this university exists
                Password = "password101",
                Username = "emilydavis",
                Role = "Client",
                CreatedDate = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<PdfSubject>().HasData(
            new PdfSubject { PdfId = 1, SubjectId = 1 },
            new PdfSubject { PdfId = 2, SubjectId = 2 },
            new PdfSubject { PdfId = 3, SubjectId = 3 }
        );

        modelBuilder.Entity<PdfUser>().HasData(
            // User 1 associated with PDF 1 and PDF 2
            new PdfUser
            {
                PdfId = 1, // PDF 1
                UserId = 1 // User 1
            },
            new PdfUser
            {
                PdfId = 2, // PDF 2
                UserId = 1 // User 1
            },
            // User 2 associated with PDF 3
            new PdfUser
            {
                PdfId = 3, // PDF 3
                UserId = 2 // User 2
            },
            // User 3 associated with PDF 4
            new PdfUser
            {
                PdfId = 4, // PDF 4
                UserId = 3 // User 3
            },
            // User 4 associated with PDF 5
            new PdfUser
            {
                PdfId = 5, // PDF 5
                UserId = 4 // User 4
            }
        );

    }



}
