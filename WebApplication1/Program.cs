using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Middlewares;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string connectionString = builder.Configuration.GetConnectionString("DbString");
            builder.Services.AddDbContext<VechicleRentalSystemDbContext>(option => option.UseSqlServer(connectionString));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
            builder.Services.AddSession();
            builder.Services.AddSingleton<CheckLoginMiddleware>();
            builder.Services.AddSingleton<CheckAdminMiddleware>();
            builder.Services.AddSingleton<CheckAdminOrDriverMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllers();

            app.Run();
        }
    }
}
