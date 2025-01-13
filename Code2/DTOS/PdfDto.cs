using Code2.DTOS;

namespace Code2.DTOs
{
    public class PdfDto
    {
        public int Id { get; set; }
        public string PdfTitle { get; set; }

        // Add this property to hold the associated subjects

        public string ThumbnailPath { get; set; }
        public float Rating { get; set; }
        public int Views { get; set; }
        public DateTime UploadedAt { get; set; }

        public List<SubjectDto> Subjects { get; set; }  // Added Subjects list
        // Add this property to hold the associated academic programs
        public List<UserDTO> Users { get; set; }
    }
}
