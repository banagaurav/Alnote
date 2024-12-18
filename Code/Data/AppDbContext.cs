using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the one-to-many relationship
        modelBuilder.Entity<Faculty>()
            .HasOne(f => f.University)
            .WithMany(u => u.Faculties)
            .HasForeignKey(f => f.UniversityId);

        // Seed data for University
        modelBuilder.Entity<University>().HasData(
            new University { Id = 1, UniversityName = "TU" },
            new University { Id = 2, UniversityName = "PU" }
        );

        // Seed data for Faculty
        modelBuilder.Entity<Faculty>().HasData(
            new Faculty { Id = 1, FacultyName = "BSc CSIT", UniversityId = 1 },
            new Faculty { Id = 2, FacultyName = "BBA", UniversityId = 1 },
            new Faculty { Id = 3, FacultyName = "MBA", UniversityId = 2 }
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
    }
}
