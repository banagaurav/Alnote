// DTOs/PdfDto.cs
using Code2.DTOS;
using Code2.Models;

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

        // Add this property to hold the associated academic programs
        public List<AcademicProgramDto> AcademicPrograms { get; set; }
    }
}
