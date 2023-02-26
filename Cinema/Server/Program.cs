using Cinema.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using MudBlazor.Services;
using Cinema.Server.Services.Movies;
using Cinema.Server.Services.Employees;
using Cinema.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;

namespace Cinema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // NOTE: This is called dependency injection
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IManagerService, ManagerService>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            //Connecting to the database
            builder.Services.AddDbContext<CinemaDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
            );

            // Setting up Identity Package
            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<CinemaDBContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, CinemaDBContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}