using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code.Models;

public class Pdf
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string PdfTitle { get; set; } // Title of the PDF

    // Foreign Key for User
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; } // Navigation property to the uploader

    // Navigation property for the many-to-many relationship
    public ICollection<PdfAcademicProgram> PdfAcademicPrograms { get; set; }

}

