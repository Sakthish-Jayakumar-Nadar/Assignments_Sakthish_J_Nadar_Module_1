using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class UserModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required, NotNull]
        public string Name { get; set; }
        [Required, NotNull, EmailAddress, MaxLength(70)]
        public string Email {  get; set; }
        [Required , NotNull, RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{4,10}$")]
        public string Password { get; set; }
        [Required, NotNull]
        public int Role {  get; set; }
        ICollection<BookingModel>Bookings { get; set; }
    }
}
