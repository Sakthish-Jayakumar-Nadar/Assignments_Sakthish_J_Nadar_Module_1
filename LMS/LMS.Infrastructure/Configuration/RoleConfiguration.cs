using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "41886008 - 6086 - 1fbf - b923 - 2879a6680b9a",
                    Name = "librarian",
                    NormalizedName = "LIBRARIAN"

                },
                new IdentityRole
                {
                    Id = "41776008 - 6086 - 1fbf - b923 - 2879a6680b9a",
                    Name = "member",
                    NormalizedName = "MEMBER"
                }
            );
        }
    }
}
