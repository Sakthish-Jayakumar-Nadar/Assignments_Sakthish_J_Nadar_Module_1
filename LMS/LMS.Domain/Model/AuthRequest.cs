using System.ComponentModel.DataAnnotations;

namespace LMS.Domain.Model
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
