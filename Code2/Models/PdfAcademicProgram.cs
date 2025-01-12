namespace Code2.Models
{
    public class PdfAcademicProgram
    {
        public int PdfId { get; set; }
        public Pdf Pdf { get; set; }  // Navigation property to Pdf

        public int AcademicProgramId { get; set; }
        public AcademicProgram AcademicProgram { get; set; }  // Navigation property to AcademicProgram
    }
}
