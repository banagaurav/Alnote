﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Code2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Academics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FacultyId = 1,
                            ProgramName = "BSc allbiology"
                        },
                        new
                        {
                            Id = 2,
                            FacultyId = 1,
                            ProgramName = "BSc Microbiology"
                        },
                        new
                        {
                            Id = 3,
                            FacultyId = 1,
                            ProgramName = "BSc Physics"
                        },
                        new
                        {
                            Id = 4,
                            FacultyId = 1,
                            ProgramName = "BSc Chemistry"
                        },
                        new
                        {
                            Id = 5,
                            FacultyId = 1,
                            ProgramName = "BSc Mathematics"
                        },
                        new
                        {
                            Id = 6,
                            FacultyId = 1,
                            ProgramName = "BSc Environmental Science"
                        },
                        new
                        {
                            Id = 7,
                            FacultyId = 2,
                            ProgramName = "BBA"
                        },
                        new
                        {
                            Id = 8,
                            FacultyId = 2,
                            ProgramName = "MBA"
                        },
                        new
                        {
                            Id = 9,
                            FacultyId = 2,
                            ProgramName = "BBS"
                        },
                        new
                        {
                            Id = 10,
                            FacultyId = 2,
                            ProgramName = "MBS"
                        },
                        new
                        {
                            Id = 11,
                            FacultyId = 2,
                            ProgramName = "BIM"
                        },
                        new
                        {
                            Id = 12,
                            FacultyId = 3,
                            ProgramName = "BA Sociology"
                        },
                        new
                        {
                            Id = 13,
                            FacultyId = 3,
                            ProgramName = "BA English"
                        },
                        new
                        {
                            Id = 14,
                            FacultyId = 3,
                            ProgramName = "BA Political Science"
                        },
                        new
                        {
                            Id = 15,
                            FacultyId = 3,
                            ProgramName = "BA Economics"
                        },
                        new
                        {
                            Id = 16,
                            FacultyId = 3,
                            ProgramName = "MA Sociology"
                        },
                        new
                        {
                            Id = 17,
                            FacultyId = 4,
                            ProgramName = "BSc CSIT"
                        },
                        new
                        {
                            Id = 18,
                            FacultyId = 4,
                            ProgramName = "BSc Microbiology"
                        },
                        new
                        {
                            Id = 19,
                            FacultyId = 4,
                            ProgramName = "BSc Environmental Science"
                        },
                        new
                        {
                            Id = 20,
                            FacultyId = 5,
                            ProgramName = "BBA"
                        },
                        new
                        {
                            Id = 21,
                            FacultyId = 5,
                            ProgramName = "MBA"
                        },
                        new
                        {
                            Id = 22,
                            FacultyId = 6,
                            ProgramName = "BA English"
                        },
                        new
                        {
                            Id = 23,
                            FacultyId = 6,
                            ProgramName = "BA Sociology"
                        },
                        new
                        {
                            Id = 24,
                            FacultyId = 7,
                            ProgramName = "BEng Computer Engineering"
                        },
                        new
                        {
                            Id = 25,
                            FacultyId = 7,
                            ProgramName = "BEng Civil Engineering"
                        },
                        new
                        {
                            Id = 26,
                            FacultyId = 7,
                            ProgramName = "BEng Electrical Engineering"
                        },
                        new
                        {
                            Id = 27,
                            FacultyId = 7,
                            ProgramName = "BEng Electronics and Communication Engineering"
                        },
                        new
                        {
                            Id = 28,
                            FacultyId = 8,
                            ProgramName = "LLB"
                        },
                        new
                        {
                            Id = 29,
                            FacultyId = 9,
                            ProgramName = "BEd"
                        },
                        new
                        {
                            Id = 30,
                            FacultyId = 9,
                            ProgramName = "MEd"
                        },
                        new
                        {
                            Id = 31,
                            FacultyId = 10,
                            ProgramName = "BFA"
                        },
                        new
                        {
                            Id = 32,
                            FacultyId = 11,
                            ProgramName = "BSc Agriculture"
                        },
                        new
                        {
                            Id = 33,
                            FacultyId = 12,
                            ProgramName = "BSc Nursing"
                        },
                        new
                        {
                            Id = 34,
                            FacultyId = 12,
                            ProgramName = "BPH"
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
                            FacultyName = "Faculty of Humanities and Social Sciences",
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
                            FacultyName = "Faculty of Education",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 5,
                            FacultyName = "Faculty of Law",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 6,
                            FacultyName = "Faculty of Fine Arts",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 7,
                            FacultyName = "Faculty of Engineering",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 8,
                            FacultyName = "Faculty of Ayurveda and Alternative Medicine",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 9,
                            FacultyName = "Faculty of Agriculture",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 10,
                            FacultyName = "Faculty of Health Sciences",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 11,
                            FacultyName = "Faculty of Humanities and Social Sciences",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 12,
                            FacultyName = "Faculty of Science",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 13,
                            FacultyName = "Faculty of Management",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 14,
                            FacultyName = "Faculty of Education",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 15,
                            FacultyName = "Faculty of Law",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 16,
                            FacultyName = "Faculty of Fine Arts",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 17,
                            FacultyName = "Faculty of Engineering",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 18,
                            FacultyName = "Faculty of Ayurveda and Alternative Medicine",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 19,
                            FacultyName = "Faculty of Agriculture",
                            UniversityId = 2
                        },
                        new
                        {
                            Id = 20,
                            FacultyName = "Faculty of Health Sciences",
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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pdfs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PdfTitle = "Introduction to C#",
                            Rating = 4.5f,
                            ThumbnailPath = "/thumbnails/intro-csharp.jpg",
                            UploadedAt = new DateTime(2025, 1, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            Views = 123
                        },
                        new
                        {
                            Id = 2,
                            PdfTitle = "Mastering ASP.NET",
                            Rating = 4.8f,
                            ThumbnailPath = "/thumbnails/mastering-aspnet.jpg",
                            UploadedAt = new DateTime(2025, 1, 11, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            Views = 89
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
                            CreatedDate = new DateTime(2025, 1, 12, 6, 18, 27, 966, DateTimeKind.Utc).AddTicks(1510),
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
                            CreatedDate = new DateTime(2025, 1, 12, 6, 18, 27, 966, DateTimeKind.Utc).AddTicks(1744),
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
                            CreatedDate = new DateTime(2025, 1, 12, 6, 18, 27, 966, DateTimeKind.Utc).AddTicks(1774),
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
                            CreatedDate = new DateTime(2025, 1, 12, 6, 18, 27, 966, DateTimeKind.Utc).AddTicks(1777),
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

            modelBuilder.Entity("Code2.Models.Pdf", b =>
                {
                    b.HasOne("Code2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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

            modelBuilder.Entity("Code2.Models.Faculty", b =>
                {
                    b.Navigation("AcademicPrograms");
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