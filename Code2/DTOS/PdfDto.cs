// DTOs/PdfDto.cs
namespace Code2.DTOs
{
    public class PdfDto
    {
        public int Id { get; set; }
        public string PdfTitle { get; set; }
        public string ThumbnailPath { get; set; }
        public float Rating { get; set; }
        public int Views { get; set; }
        public DateTime UploadedAt { get; set; }
        public string UploadedBy { get; set; } // FullName of the uploader
    }
}
