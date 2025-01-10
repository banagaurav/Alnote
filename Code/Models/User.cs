using System;
using System.ComponentModel.DataAnnotations;

namespace Code.Models;

public class User
{
    [Key]
    public int UserId { get; set; } // Primary Key

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; } // Username for login

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } // User's email address

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } // Encrypted password

    [Required]
    [StringLength(20)]
    public string Role { get; set; } // Role of the user, e.g., Admin, Client

    public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the user is created

    // Navigation property for PDFs uploaded by the user
    public ICollection<Pdf> UploadedPdfs { get; set; }
}
