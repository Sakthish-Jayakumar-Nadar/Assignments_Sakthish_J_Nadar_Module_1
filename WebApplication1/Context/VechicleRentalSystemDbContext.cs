using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class VechicleRentalSystemDbContext : DbContext
    {
        public VechicleRentalSystemDbContext(DbContextOptions<VechicleRentalSystemDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasAlternateKey(user => user.Email);
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
    }
}
