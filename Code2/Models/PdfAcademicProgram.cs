using Code2.Models;

public class PdfAcademicProgram
{
    // Composite Primary Key: PdfId + AcademicProgramId
    public int PdfId { get; set; }
    public Pdf Pdf { get; set; } // Navigation property

    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; } // Navigation property
}
