﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Code2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250114110012_PutSubject")]
    partial class PutSubject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Code2.Models.AcademicProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfYears")
                        .HasColumnType("int");

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Academics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FacultyId = 1,
                            NoOfYears = 3,
                            ProgramName = "BA English",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            FacultyId = 1,
                            NoOfYears = 3,
                            ProgramName = "BA Sociology",
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            FacultyId = 2,
                            NoOfYears = 4,
                            ProgramName = "BSc Computer Science",
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            FacultyId = 2,
                            NoOfYears = 4,
                            ProgramName = "BSc Microbiology",
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            FacultyId = 3,
                            NoOfYears = 4,
                            ProgramName = "BBA",
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            FacultyId = 3,
                            NoOfYears = 2,
                            ProgramName = "MBA",
                            Type = 1
                        },
                        new
                        {
                            Id = 7,
                            FacultyId = 4,
                            NoOfYears = 5,
                            ProgramName = "LLB",
                            Type = 0
                        },
                        new
                        {
                            Id = 8,
                            FacultyId = 4,
                            NoOfYears = 2,
                            ProgramName = "LLM",
                            Type = 0
                        },
                        new
                        {
                            Id = 9,
                            FacultyId = 5,
                            NoOfYears = 2,
                            ProgramName = "BEd",
                            Type = 0
                        },
                        new
                        {
                            Id = 10,
                            FacultyId = 5,
                            NoOfYears = 2,
                            ProgramName = "MEd",
                            Type = 0
                        },
                        new
                        {
                            Id = 11,
                            FacultyId = 6,
                            NoOfYears = 4,
                            ProgramName = "BEng Civil Engineering",
                            Type = 1
                        },
                        new
                        {
                            Id = 12,
                            FacultyId = 6,
                            NoOfYears = 4,
                            ProgramName = "BEng Electrical Engineering",
                            Type = 1
                        },
                        new
                        {
                            Id = 13,
                            FacultyId = 7,
                            NoOfYears = 3,
                            ProgramName = "BSc Chemistry",
                            Type = 0
                        },
                        new
                        {
                            Id = 14,
                            FacultyId = 7,
                            NoOfYears = 3,
                            ProgramName = "BSc Physics",
                            Type = 0
                        },
                        new
                        {
                            Id = 15,
                            FacultyId = 8,
                            NoOfYears = 4,
                            ProgramName = "BBA",
                            Type = 1
                        },
                        new
                        {
                            Id = 16,
                            FacultyId = 8,
                            NoOfYears = 2,
                            ProgramName = "MBA",
                            Type = 1
                        },
                        new
                        {
                            Id = 17,
                            FacultyId = 9,
                            NoOfYears = 5,
                            ProgramName = "LLB",
                            Type = 0
                        },
                        new
                        {
                            Id = 18,
                            FacultyId = 9,
                            NoOfYears = 2,
                            ProgramName = "LLM",
                            Type = 0
                        },
                        new
                        {
                            Id = 19,
                            FacultyId = 10,
                            NoOfYears = 4,
                            ProgramName = "BFA",
                            Type = 0
                        });
                });

            modelBuilder.Entity("Code2.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FacultyName = "Faculty of Humanities",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 2,
                            FacultyName = "Faculty of Science",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 3,
                            FacultyName = "Faculty of Management",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 4,
                            FacultyName = "Faculty of Law",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 5,
                            FacultyName = "Faculty of Education",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 6,
                            FacultyName = "Faculty of Engineering",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 7,
                            FacultyName = "Faculty of Science",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 8,
                            FacultyName = "Faculty of Management",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 9,
                            FacultyName = "Faculty of Law",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 10,
                            FacultyName = "Faculty of Fine Arts",
                            UniversityId = 2
                        });
                });

            modelBuilder.Entity("Code2.Models.Pdf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PdfTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("ThumbnailPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pdfs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PdfTitle = "BSc CSIT Course Material 1",
                            Rating = 4.5f,
                            ThumbnailPath = "path/to/thumbnail1.jpg",
                            UploadedAt = new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9079),
                            Views = 100
                        },
                        new
                        {
                            Id = 2,
                            PdfTitle = "BSc Microbiology Course Material 1",
                            Rating = 4f,
                            ThumbnailPath = "path/to/thumbnail2.jpg",
                            UploadedAt = new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9321),
                            Views = 200
                        },
                        new
                        {
                            Id = 3,
                            PdfTitle = "BBA and MBA Case Studies",
                            Rating = 4.8f,
                            ThumbnailPath = "path/to/thumbnail3.jpg",
                            UploadedAt = new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9322),
                            Views = 150
                        },
                        new
                        {
                            Id = 4,
                            PdfTitle = "BBA and BIM Overview",
                            Rating = 4.2f,
                            ThumbnailPath = "path/to/thumbnail4.jpg",
                            UploadedAt = new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9324),
                            Views = 50
                        },
                        new
                        {
                            Id = 5,
                            PdfTitle = "BSc Agriculture and BSc Nursing Guide",
                            Rating = 4.1f,
                            ThumbnailPath = "path/to/thumbnail5.jpg",
                            UploadedAt = new DateTime(2025, 1, 14, 11, 0, 11, 320, DateTimeKind.Utc).AddTicks(9325),
                            Views = 250
                        });
                });

            modelBuilder.Entity("Code2.Models.PdfSubject", b =>
                {
                    b.Property<int>("PdfId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("PdfId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("PdfSubjects");

                    b.HasData(
                        new
                        {
                            PdfId = 1,
                            SubjectId = 1
                        },
                        new
                        {
                            PdfId = 2,
                            SubjectId = 2
                        },
                        new
                        {
                            PdfId = 3,
                            SubjectId = 3
                        });
                });

            modelBuilder.Entity("Code2.Models.PdfUser", b =>
                {
                    b.Property<int>("PdfId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PdfId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PdfUsers");

                    b.HasData(
                        new
                        {
                            PdfId = 1,
                            UserId = 1
                        },
                        new
                        {
                            PdfId = 2,
                            UserId = 1
                        },
                        new
                        {
                            PdfId = 3,
                            UserId = 2
                        },
                        new
                        {
                            PdfId = 4,
                            UserId = 3
                        },
                        new
                        {
                            PdfId = 5,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("Code2.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademicProgramId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcademicProgramId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcademicProgramId = 3,
                            SubjectCode = "CSIT101",
                            SubjectName = "Mathematics I"
                        },
                        new
                        {
                            Id = 2,
                            AcademicProgramId = 3,
                            SubjectCode = "CSIT102",
                            SubjectName = "Physics I"
                        },
                        new
                        {
                            Id = 3,
                            AcademicProgramId = 3,
                            SubjectCode = "CSIT103",
                            SubjectName = "Computer Science Basics"
                        },
                        new
                        {
                            Id = 4,
                            AcademicProgramId = 18,
                            SubjectCode = "MICRO101",
                            SubjectName = "Microbiology Fundamentals"
                        },
                        new
                        {
                            Id = 5,
                            AcademicProgramId = 18,
                            SubjectCode = "MICRO102",
                            SubjectName = "Organic Chemistry"
                        },
                        new
                        {
                            Id = 6,
                            AcademicProgramId = 6,
                            SubjectCode = "ENV101",
                            SubjectName = "Environmental Science Basics"
                        },
                        new
                        {
                            Id = 7,
                            AcademicProgramId = 6,
                            SubjectCode = "ENV102",
                            SubjectName = "Biodiversity"
                        },
                        new
                        {
                            Id = 8,
                            AcademicProgramId = 7,
                            SubjectCode = "BBA101",
                            SubjectName = "Principles of Management"
                        },
                        new
                        {
                            Id = 9,
                            AcademicProgramId = 7,
                            SubjectCode = "BBA102",
                            SubjectName = "Business Statistics"
                        },
                        new
                        {
                            Id = 10,
                            AcademicProgramId = 8,
                            SubjectCode = "MBA101",
                            SubjectName = "Advanced Accounting"
                        },
                        new
                        {
                            Id = 11,
                            AcademicProgramId = 8,
                            SubjectCode = "MBA102",
                            SubjectName = "Marketing Management"
                        },
                        new
                        {
                            Id = 12,
                            AcademicProgramId = 11,
                            SubjectCode = "BIM101",
                            SubjectName = "Database Management Systems"
                        },
                        new
                        {
                            Id = 13,
                            AcademicProgramId = 11,
                            SubjectCode = "BIM102",
                            SubjectName = "Software Engineering"
                        },
                        new
                        {
                            Id = 14,
                            AcademicProgramId = 3,
                            SubjectCode = "AGRI101",
                            SubjectName = "Agriculture Economics"
                        },
                        new
                        {
                            Id = 15,
                            AcademicProgramId = 3,
                            SubjectCode = "AGRI102",
                            SubjectName = "Crop Production"
                        },
                        new
                        {
                            Id = 16,
                            AcademicProgramId = 3,
                            SubjectCode = "NUR101",
                            SubjectName = "Anatomy and Physiology"
                        },
                        new
                        {
                            Id = 17,
                            AcademicProgramId = 3,
                            SubjectCode = "NUR102",
                            SubjectName = "Community Health Nursing"
                        },
                        new
                        {
                            Id = 18,
                            AcademicProgramId = 7,
                            SubjectCode = "BBA103",
                            SubjectName = "Human Resource Management"
                        },
                        new
                        {
                            Id = 19,
                            AcademicProgramId = 8,
                            SubjectCode = "MBA103",
                            SubjectName = "Business Ethics"
                        },
                        new
                        {
                            Id = 20,
                            AcademicProgramId = 17,
                            SubjectCode = "CSIT104",
                            SubjectName = "Data Structures"
                        });
                });

            modelBuilder.Entity("Code2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentSchoolOrCollege")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.Property<int?>("UniversityId1")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("UniversityId");

                    b.HasIndex("UniversityId1");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedDate = new DateTime(2025, 1, 14, 11, 0, 11, 321, DateTimeKind.Utc).AddTicks(2475),
                            CurrentSchoolOrCollege = "XYZ College",
                            DateOfBirth = new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "password123",
                            PhoneNumber = "123-456-7890",
                            Role = "Admin",
                            UniversityId = 1,
                            Username = "johndoe"
                        },
                        new
                        {
                            UserId = 2,
                            CreatedDate = new DateTime(2025, 1, 14, 11, 0, 11, 321, DateTimeKind.Utc).AddTicks(2737),
                            CurrentSchoolOrCollege = "ABC University",
                            DateOfBirth = new DateTime(1992, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "janesmith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Password = "password456",
                            PhoneNumber = "987-654-3210",
                            Role = "Client",
                            UniversityId = 1,
                            Username = "janesmith"
                        },
                        new
                        {
                            UserId = 3,
                            CreatedDate = new DateTime(2025, 1, 14, 11, 0, 11, 321, DateTimeKind.Utc).AddTicks(2739),
                            CurrentSchoolOrCollege = "PQR Institute",
                            DateOfBirth = new DateTime(1988, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michaelj@example.com",
                            FirstName = "Michael",
                            LastName = "Johnson",
                            Password = "password789",
                            PhoneNumber = "555-123-9876",
                            Role = "Client",
                            Username = "michaeljohnson"
                        },
                        new
                        {
                            UserId = 4,
                            CreatedDate = new DateTime(2025, 1, 14, 11, 0, 11, 321, DateTimeKind.Utc).AddTicks(2741),
                            CurrentSchoolOrCollege = "LMN College",
                            DateOfBirth = new DateTime(1995, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emilydavis@example.com",
                            FirstName = "Emily",
                            LastName = "Davis",
                            Password = "password101",
                            PhoneNumber = "123-789-4560",
                            Role = "Client",
                            UniversityId = 2,
                            Username = "emilydavis"
                        });
                });

            modelBuilder.Entity("University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Universities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UniversityName = "TU"
                        },
                        new
                        {
                            Id = 2,
                            UniversityName = "PU"
                        });
                });

            modelBuilder.Entity("Code2.Models.AcademicProgram", b =>
                {
                    b.HasOne("Code2.Models.Faculty", "Faculty")
                        .WithMany("AcademicPrograms")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Code2.Models.Faculty", b =>
                {
                    b.HasOne("University", "University")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Code2.Models.PdfSubject", b =>
                {
                    b.HasOne("Code2.Models.Pdf", "Pdf")
                        .WithMany("PdfSubjects")
                        .HasForeignKey("PdfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Code2.Models.Subject", "Subject")
                        .WithMany("PdfSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pdf");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Code2.Models.PdfUser", b =>
                {
                    b.HasOne("Code2.Models.Pdf", "Pdf")
                        .WithMany("PdfUsers")
                        .HasForeignKey("PdfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Code2.Models.User", "User")
                        .WithMany("PdfUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pdf");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Code2.Models.Subject", b =>
                {
                    b.HasOne("Code2.Models.AcademicProgram", "AcademicProgram")
                        .WithMany("Subjects")
                        .HasForeignKey("AcademicProgramId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AcademicProgram");
                });

            modelBuilder.Entity("Code2.Models.User", b =>
                {
                    b.HasOne("University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("University", null)
                        .WithMany("Users")
                        .HasForeignKey("UniversityId1");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Code2.Models.AcademicProgram", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Code2.Models.Faculty", b =>
                {
                    b.Navigation("AcademicPrograms");
                });

            modelBuilder.Entity("Code2.Models.Pdf", b =>
                {
                    b.Navigation("PdfSubjects");

                    b.Navigation("PdfUsers");
                });

            modelBuilder.Entity("Code2.Models.Subject", b =>
                {
                    b.Navigation("PdfSubjects");
                });

            modelBuilder.Entity("Code2.Models.User", b =>
                {
                    b.Navigation("PdfUsers");
                });

            modelBuilder.Entity("University", b =>
                {
                    b.Navigation("Faculties");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}