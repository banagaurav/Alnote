using System;
using System.ComponentModel.DataAnnotations;

namespace Code2.DTOS;

public class CreateFacultyDto
{
    [Required]
    public string FacultyName { get; set; }
    [Required]
    public int UniversityId { get; set; }  // Only the UniversityId for creating
}

