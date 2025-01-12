using Microsoft.EntityFrameworkCore;
using Code2.Models;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    // Other DbSets (e.g., Pdfs, Faculties)
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<AcademicProgram> Academics { get; set; }
    public DbSet<Pdf> Pdfs { get; set; }
    public DbSet<PdfAcademicProgram> PdfAcademicPrograms { get; set; }

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

        // Configure the many-to-many relationship
        modelBuilder.Entity<PdfAcademicProgram>()
            .HasKey(pap => new { pap.PdfId, pap.AcademicProgramId });  // Composite primary key

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
            new AcademicProgram { Id = 1, ProgramName = "BSc allbiology", FacultyId = 1 },
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

        modelBuilder.Entity<Pdf>().HasData(
     // PDF 1 for BSc CSIT and BSc Microbiology
     new Pdf
     {
         Id = 1,
         PdfTitle = "BSc CSIT Course Material 1",
         UserId = 1,
         ThumbnailPath = "path/to/thumbnail1.jpg",
         Rating = 4.5f,
         Views = 100,
         UploadedAt = DateTime.UtcNow,
         UploadedBy = "John Doe"
     },
     // PDF 2 for BSc Microbiology and BSc Environmental Science
     new Pdf
     {
         Id = 2,
         PdfTitle = "BSc Microbiology Course Material 1",
         UserId = 2,
         ThumbnailPath = "path/to/thumbnail2.jpg",
         Rating = 4.0f,
         Views = 200,
         UploadedAt = DateTime.UtcNow,
         UploadedBy = "Jane Doe"
     },
     // PDF 3 for BBA and MBA
     new Pdf
     {
         Id = 3,
         PdfTitle = "BBA and MBA Case Studies",
         UserId = 3,
         ThumbnailPath = "path/to/thumbnail3.jpg",
         Rating = 4.8f,
         Views = 150,
         UploadedAt = DateTime.UtcNow,
         UploadedBy = "Emily Smith"
     },
     // PDF 4 for BBA and BIM
     new Pdf
     {
         Id = 4,
         PdfTitle = "BBA and BIM Overview",
         UserId = 4,
         ThumbnailPath = "path/to/thumbnail4.jpg",
         Rating = 4.2f,
         Views = 50,
         UploadedAt = DateTime.UtcNow,
         UploadedBy = "David Johnson"
     },
     // PDF 5 for BSc Agriculture and BSc Nursing
     new Pdf
     {
         Id = 5,
         PdfTitle = "BSc Agriculture and BSc Nursing Guide",
         UserId = 3,
         ThumbnailPath = "path/to/thumbnail5.jpg",
         Rating = 4.1f,
         Views = 250,
         UploadedAt = DateTime.UtcNow,
         UploadedBy = "Sarah Lee"
     }
 );


        modelBuilder.Entity<PdfAcademicProgram>().HasData(
            // PDF 1 associated with BSc CSIT and BSc Microbiology
            new PdfAcademicProgram { PdfId = 1, AcademicProgramId = 17 },  // BSc CSIT for TU Faculty of Science
            new PdfAcademicProgram { PdfId = 1, AcademicProgramId = 18 },  // BSc Microbiology for TU Faculty of Science

            // PDF 2 associated with BSc Microbiology and BSc Environmental Science
            new PdfAcademicProgram { PdfId = 2, AcademicProgramId = 18 },  // BSc Microbiology for TU Faculty of Science
            new PdfAcademicProgram { PdfId = 2, AcademicProgramId = 6 },   // BSc Environmental Science for TU Faculty of Science

            // PDF 3 associated with BBA and MBA
            new PdfAcademicProgram { PdfId = 3, AcademicProgramId = 7 },   // BBA for TU Faculty of Management
            new PdfAcademicProgram { PdfId = 3, AcademicProgramId = 8 },   // MBA for TU Faculty of Management

            // PDF 4 associated with BBA and BIM
            new PdfAcademicProgram { PdfId = 4, AcademicProgramId = 7 },   // BBA for TU Faculty of Management
            new PdfAcademicProgram { PdfId = 4, AcademicProgramId = 11 },  // BIM for TU Faculty of Management

            // PDF 5 associated with BSc Agriculture and BSc Nursing
            new PdfAcademicProgram { PdfId = 5, AcademicProgramId = 32 },  // BSc Agriculture for PU Faculty of Agriculture
            new PdfAcademicProgram { PdfId = 5, AcademicProgramId = 33 }   // BSc Nursing for PU Faculty of Health Sciences
);
    }


}
