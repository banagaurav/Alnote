using System;

namespace Code2.DTOS;

public class FacultyDto
{
    public int Id { get; set; }
    public string FacultyName { get; set; }
    public UniversityDto University { get; set; }
}
