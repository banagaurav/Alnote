using System;
using System.ComponentModel.DataAnnotations;

namespace Code2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string CurrentSchoolOrCollege { get; set; }

        public int? UniversityId { get; set; }
        public University University { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        // This is a derived property that combines first and last name
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Automatically set to the current UTC time when the user is created
    }
}
