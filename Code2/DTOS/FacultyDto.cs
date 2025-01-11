using System;
using System.ComponentModel.DataAnnotations;

namespace Code2.DTOS
{
    public class FacultyDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Faculty name is required.")]
        [StringLength(100, ErrorMessage = "Faculty name cannot be longer than 100 characters.")]
        public string FacultyName { get; set; }

        [Required(ErrorMessage = "University is required.")]
        public UniversityDto University { get; set; }
    }
}
