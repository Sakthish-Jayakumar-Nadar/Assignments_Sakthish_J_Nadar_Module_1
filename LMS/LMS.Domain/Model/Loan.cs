using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LMS.Domain.Model
{
    public class Loan
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, NotNull]
        public string MemberId { get; set; }
        [NotMapped]
        public string Email { get; set; }   
        [JsonIgnore]
        public Member? Member { get; set; }
        [Required, NotNull]
        public int BookId { get; set; }
        [NotMapped]
        public string BookName { get; set; }
        [JsonIgnore]
        public Book? Book { get; set; }
        [Required, NotNull]
        public DateTime LoanDate { get; set; }
        [Required, NotNull]
        public DateTime DueDate { get; set; }
        [Required, NotNull]
        public DateTime ReturnDate { get; set; }
        [Required, NotNull]
        public DateTime BorrowRequestTime { get; set; }
        [Required, NotNull]
        public int Status { get; set; }
    }
}
