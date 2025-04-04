
using System.Reflection;
using System.Text;
using LMS.Domain.Interface;
using LMS.Domain.Model;
using LMS.Infrastructure.Context;
using LMS.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using LMS.Application.Feature.Query.GetBooks;
using LMS.Infrastructure.Expire;
using LMS.API.Middleware;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBooksQueryHandler).Assembly));
            builder.Services.AddDbContext<LMSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LMSConString")));
            builder.Services.AddIdentity<Member, IdentityRole>().AddEntityFrameworkStores<LMSDbContext>().AddDefaultTokenProviders();
            builder.Services.AddTransient<IAuthRepository, AuthRepository>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
                };
            });
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddHostedService<ExpireBorrowBookRequest>();
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
