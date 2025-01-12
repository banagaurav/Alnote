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

    // New method for mapping Pdf to PdfDto
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
            UploadedBy = pdf.UploadedBy, // Assuming the full name is stored in the UploadedBy field

            // Mapping the many-to-many relation between Pdf and AcademicProgram
            AcademicPrograms = pdf.PdfAcademicPrograms
                .Select(pap => new AcademicProgramDto
                {
                    Id = pap.AcademicProgram.Id,
                    ProgramName = pap.AcademicProgram.ProgramName,
                    Faculty = new FacultyDto
                    {
                        Id = pap.AcademicProgram.Faculty.Id,
                        FacultyName = pap.AcademicProgram.Faculty.FacultyName,
                        University = new UniversityDto
                        {
                            Id = pap.AcademicProgram.Faculty.University.Id,
                            UniversityName = pap.AcademicProgram.Faculty.University.UniversityName
                        }
                    }
                }).ToList() // Convert the collection to a list
        };

    }
}
