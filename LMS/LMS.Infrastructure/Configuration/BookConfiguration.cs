using LMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "Your Name",
                    BookCount = 5,
                    Author = "Kisimoto",
                    PublishedYear = DateOnly.Parse("10/7/2001"),
                    CategoryId = 1
                });
        }
    }
}
