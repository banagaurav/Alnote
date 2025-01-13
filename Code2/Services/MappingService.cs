using System;
using Code2.DTOs;
using Code2.DTOS;
using Code2.Models;

namespace Code2.Services;

public class MappingService
{
    public FacultyDto MapToFacultyDto(Faculty faculty)
    {
        return new FacultyDto
        {
            Id = faculty.Id,
            FacultyName = faculty.FacultyName,
            University = faculty.University != null ? new UniversityDto
            {
                Id = faculty.University.Id,
                UniversityName = faculty.University.UniversityName
            } : null // Make sure university is included
        };
    }


    public AcademicProgramDto MapToAcademicProgramDto(AcademicProgram academicProgram)
    {
        return new AcademicProgramDto
        {
            Id = academicProgram.Id,
            ProgramName = academicProgram.ProgramName,
            Faculty = new FacultyDto
            {
                Id = academicProgram.Faculty.Id,
                FacultyName = academicProgram.Faculty.FacultyName,
                University = new UniversityDto
                {
                    Id = academicProgram.Faculty.University.Id,
                    UniversityName = academicProgram.Faculty.University.UniversityName
                }
            },
        };
    }


    public SubjectDto MapToSubjectDto(Subject subject)
    {
        return new SubjectDto
        {
            Id = subject.Id,
            SubjectName = subject.SubjectName,
            AcademicProgram = new AcademicProgramDto
            {
                Id = subject.AcademicProgram.Id,
                ProgramName = subject.AcademicProgram.ProgramName,
                Faculty = new FacultyDto
                {
                    Id = subject.AcademicProgram.Faculty.Id,
                    FacultyName = subject.AcademicProgram.Faculty.FacultyName,
                    University = new UniversityDto
                    {
                        Id = subject.AcademicProgram.Faculty.University.Id,
                        UniversityName = subject.AcademicProgram.Faculty.University.UniversityName
                    }
                }
            }
        };
    }
    public UserDTO MapToUserDto(User user)
    {
        if (user == null)
        {
            return null;
        }

        return new UserDTO
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        };
    }

    public PdfDto MapToPdfDto(Pdf pdf)
    {
        return new PdfDto
        {
            Id = pdf.Id,
            PdfTitle = pdf.PdfTitle,
            ThumbnailPath = pdf.ThumbnailPath,
            Rating = pdf.Rating,
            Views = pdf.Views,
            UploadedAt = pdf.UploadedAt,

            // Mapping the many-to-many relation between Pdf and Subject
            Subjects = pdf.PdfSubjects
                .Select(ps => new SubjectDto
                {
                    Id = ps.Subject.Id,
                    SubjectName = ps.Subject.SubjectName,

                    // Mapping the Subject -> AcademicProgram -> Faculty -> University
                    AcademicProgram = new AcademicProgramDto
                    {
                        Id = ps.Subject.AcademicProgram.Id,
                        ProgramName = ps.Subject.AcademicProgram.ProgramName,

                        // Mapping AcademicProgram -> Faculty -> University
                        Faculty = new FacultyDto
                        {
                            Id = ps.Subject.AcademicProgram.Faculty.Id,
                            FacultyName = ps.Subject.AcademicProgram.Faculty.FacultyName,

                            // Mapping Faculty -> University
                            University = new UniversityDto
                            {
                                Id = ps.Subject.AcademicProgram.Faculty.University.Id,
                                UniversityName = ps.Subject.AcademicProgram.Faculty.University.UniversityName
                            }
                        }
                    }
                }).ToList(), // Convert the collection to a list

            // Mapping many-to-many relation between Pdf and User
            Users = pdf.PdfUsers
                .Select(pu => new UserDTO
                {
                    UserId = pu.User.UserId,
                    Username = pu.User.Username,
                    Email = pu.User.Email
                }).ToList()
        };
    }



}
