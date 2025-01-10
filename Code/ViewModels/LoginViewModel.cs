using System.ComponentModel.DataAnnotations;

namespace Code.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; } // Can be either username or email

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } // User password
    }
}
