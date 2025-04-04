using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LMS.Domain.Model
{
    public class Category
    {
        [Key, NotNull, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, NotNull]
        public string Name { get; set; }
        [Required, NotNull]
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Book>? Books { get; set; }
    }
}
