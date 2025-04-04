using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class BookingModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Required, NotNull]
        public int VehicleId { get; set; }
        [Required, NotNull]
        public int UserId {  get; set; }
        [Required, NotNull]
        public int StartLocation { get; set; }
        [Required, NotNull]
        public DateTime StartDate { get; set; }
        [Required, NotNull]
        public DateTime EndDate { get; set; }
        [Required, NotNull]
        public decimal TotalAmount { get; set; }
        [Required, NotNull]
        public int Status { get; set; }
        public UserModel User { get; set; }
        public VehicleModel Vehicle { get; set; }

    }
}
