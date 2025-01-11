using System;

namespace Code2.DTOS;

public class AcademicProgramDto
{
    public int Id { get; set; }
    public string ProgramName { get; set; }
    public FacultyDto Faculty { get; set; }

}

