namespace Code2.Models
{
    public class PdfSubject
    {
        public int PdfId { get; set; }
        public Pdf Pdf { get; set; }  // Navigation property to Pdf

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }  // Navigation property to Subject
    }
}
