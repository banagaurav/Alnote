namespace Code2.Models;

public class Subject
{
    public int Id { get; set; }  // Primary Key
    public string SubjectName { get; set; }  // Name of the program, e.g., BCA, BIM, etc.
    public string SubjectCode { get; set; }


    // Foreign Key for Faculty
    public int AcademicProgramId { get; set; }

    // Navigation property to Faculty
    public AcademicProgram AcademicProgram { get; set; }
    public ICollection<PdfSubject> PdfSubjects { get; set; }  // Navigation property
}
