using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LMS.Domain.Model
{
    public class Book
    {
        //Id, Title, Author, ISBN, CategoryId, PublishedYear, CopiesAvailable
        [Key, NotNull, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required , NotNull, StringLength(150)]
        public string Title { get; set; }
        //[Required, NotNull]
        //public byte[] CoverPhoto { get; set; }
        [Required, NotNull]
        public int BookCount { get; set; }
        [Required, NotNull]
        public string Author {  get; set; }
        [Required, NotNull]
        public DateOnly PublishedYear { get; set; }
        [Required, NotNull]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
