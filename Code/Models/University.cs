using System.ComponentModel.DataAnnotations;

public class University
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string UniversityName { get; set; }

    // Navigation property for Faculties
    public ICollection<Faculty> Faculties { get; set; }
}
