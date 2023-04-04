using Microsoft.EntityFrameworkCore;
using Cinema.DataAccess.Context;
using Cinema.DataAccess.Services.UnitOfWorkServices;

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

            // NOTE: This is called dependency 
            //builder.Services.AddScoped<IMovieService, MovieService>();
            //builder.Services.AddScoped<IManagerService, ManagerService>();
            //builder.Services.AddScoped<IAdminService, AdminService>();
            //builder.Services.AddScoped<IBookingService, BookingService>();

            // Replace all above services with UnitOfWork service.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Connecting to the database
            builder.Services.AddDbContext<CinemaDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
            );

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


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}