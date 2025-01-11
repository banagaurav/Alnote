using System;
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

}
