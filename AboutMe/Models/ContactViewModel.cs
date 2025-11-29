using System.ComponentModel.DataAnnotations;

namespace AboutMe.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Display(Name = "Your Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a message")]
        [StringLength(1000, MinimumLength = 10,
            ErrorMessage = "Message must be between 10 and 1000 characters")]
        [Display(Name = "Your Message")]
        public string Message { get; set; } = string.Empty;
    }
}