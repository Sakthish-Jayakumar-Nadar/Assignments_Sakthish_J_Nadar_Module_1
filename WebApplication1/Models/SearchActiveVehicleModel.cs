using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using WebApplication1.Middlewares;

namespace WebApplication1.Models
{
    public class SearchActiveVehicleModel
    {
        [Required, NotNull]
        public int StartLocation { get; set; }
        [Required, NotNull, DateTimeValidation(ErrorMessage = "Date and time should be grater the now")]
        public DateTime StartDate { get; set; }
        [Required, NotNull, DateTimeValidation(ErrorMessage = "Date and time should be grater the now")]
        public DateTime EndDate { get; set; }
    }
}
