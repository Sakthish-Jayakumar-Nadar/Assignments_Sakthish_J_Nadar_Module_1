using LMS.Domain.Model;
using LMS.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Context
{
    public class LMSDbContext : IdentityDbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Member>().HasMany(m => m.Loans).WithOne(l => l.Member).HasForeignKey(l => l.MemberId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
