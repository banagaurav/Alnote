namespace Code2.Models;

public class AcademicProgram
{
    public int Id { get; set; }  // Primary Key
    public string ProgramName { get; set; }  // Name of the program, e.g., BCA, BIM, etc.

    // Foreign Key for Faculty
    public int FacultyId { get; set; }

    // Navigation property to Faculty
    public Faculty Faculty { get; set; }

    // Navigation property for the many-to-many relationship
    public ICollection<PdfAcademicProgram> PdfAcademicPrograms { get; set; }
}
