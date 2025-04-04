using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class LoginUserModel
    {
        [Required, NotNull, EmailAddress, MaxLength(70)]
        public string Email { get; set; }
        [Required, NotNull]
        public string Password { get; set; }
    }
}
