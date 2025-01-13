using System.ComponentModel.DataAnnotations;

namespace Code2.Models;

public class AcademicProgram
{
    [Key]
    public int Id { get; set; }  // Primary Key
    public string ProgramName { get; set; }  // Name of the program, e.g., BCA, BIM, etc.
    public int Type { get; set; } // 0 for year and 1 for semester
    public int NoOfYears { get; set; }

    // Foreign Key for Faculty
    public int FacultyId { get; set; }

    // Navigation property to Faculty
    public Faculty Faculty { get; set; }


    // Add this navigation property for Subjects
    public ICollection<Subject> Subjects { get; set; }
}

