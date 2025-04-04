using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace WebApplication1.Models
{
    public class VehicleModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        [Required, NotNull]
        public int UserId { get; set; }
        [Required, NotNull, NotMapped, DataType(DataType.ImageUrl)]
        public IFormFile VehicleImage { get; set; }
        [Required, NotNull]
        public string VehicleImageContentType { get; set; }
        [Required, NotNull]
        public byte[] VehicleImageBytes { get; set; }
        [Required, NotNull]
        public string Model { get; set; }
        [Required, NotNull]
        public string Brand { get; set; }
        [Required, NotNull]
        public int Type { get; set; }
        [Required, NotNull]
        public int Location {  get; set; }
        [Required, NotNull]
        public decimal RentalPricePerDay { get; set; }
        [Required, NotNull]
        public bool IsAvailable { get; set; }
        public UserModel User { get; set; }
        public ICollection<BookingModel> Bookings { get; set; }
    }
}
