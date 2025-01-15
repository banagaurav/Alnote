using System;
using Code2.DTOs;
using Code2.DTOS;
using Code2.Models;
using Microsoft.AspNetCore.Identity;

namespace Code2.Services;

public class MappingService
{
    public UniversityDto MapToUniversityDto(University university)
    {
        if (university == null) return null;

        return new UniversityDto
        {
            Id = university.Id,
            UniversityName = university.UniversityName
        };
    }
    public FacultyDto MapToFacultyDto(Faculty faculty)
    {
        if (faculty == null) return null;

        return new FacultyDto
        {
            Id = faculty.Id,
            FacultyName = faculty.FacultyName,
            University = MapToUniversityDto(faculty.University)
        };
    }


    public AcademicProgramDto MapToAcademicProgramDto(AcademicProgram academicProgram)
    {
        if (academicProgram == null) return null;

        return new AcademicProgramDto
        {
            Id = academicProgram.Id,
            ProgramName = academicProgram.ProgramName,
            NoOfYears = academicProgram.NoOfYears,
            Type = academicProgram.Type,
            Faculty = MapToFacultyDto(academicProgram.Faculty)
        };
    }

    public SubjectDto MapToSubjectDto(Subject subject)
    {
        if (subject == null) return null;

        return new SubjectDto
        {
            Id = subject.Id,
            SubjectName = subject.SubjectName,
            SubjectCode = subject.SubjectCode,
            AcademicProgram = MapToAcademicProgramDto(subject.AcademicProgram)
        };
    }


    public SubjectOnlyDto MapToSubjectOnlyDto(Subject subject)
    {
        return new SubjectOnlyDto
        {
            Id = subject.Id,
            SubjectName = subject.SubjectName,
            SubjectCode = subject.SubjectCode
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
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            CurrentSchoolOrCollege = user.CurrentSchoolOrCollege,
            UniversityId = user.UniversityId,
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

            Subjects = pdf.PdfSubjects?.Select(ps => MapToSubjectDto(ps.Subject)).ToList() ?? new List<SubjectDto>(),
            Users = pdf.PdfUsers?.Select(pu => MapToUserDto(pu.User)).ToList() ?? new List<UserDTO>()
        };
    }

}




