namespace Code2.Models
{
    public class PdfUser
    {
        public int PdfId { get; set; }
        public Pdf Pdf { get; set; }  // Navigation property to Pdf

        public int UserId { get; set; }
        public User User { get; set; }  // Navigation property to User
    }
}
