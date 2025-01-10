using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Faculty
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FacultyName { get; set; }

    // Foreign Key for University
    public int UniversityId { get; set; }

    [ForeignKey("UniversityId")]
    public University University { get; set; }

    public ICollection<AcademicProgram> AcademicPrograms { get; set; }
}
