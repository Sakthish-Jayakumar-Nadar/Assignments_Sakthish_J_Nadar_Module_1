using LMS.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            var hasher = new PasswordHasher<Member>();
            builder.HasData(
                new Member
                {
                    Id = "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "Admin@123")

                },
                 new Member
                 {
                     Id = "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                     Email = "shree@gmail.com",
                     NormalizedEmail = "SHREE@GMAIL.COM",
                     UserName = "shreekanth",
                     NormalizedUserName = "SHREEKANTH",
                     PasswordHash = hasher.HashPassword(null, "Shree@123")
                 }
            );
        }
}
}
