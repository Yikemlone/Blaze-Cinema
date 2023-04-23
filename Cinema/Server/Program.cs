using Microsoft.EntityFrameworkCore;
using Cinema.DataAccess.Context;
using Cinema.Models.Models;
using Cinema.DataAccess.Services.UnitOfWorkServices;
using Microsoft.AspNetCore.Identity;

namespace Cinema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddDbContext<CinemaDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
            );

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<CinemaDBContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("IsAdmin", policy => policy.RequireClaim("AdminRole", "admin"));
                options.AddPolicy("IsManager", policy => policy.RequireClaim("ManagerRole", "manager"));
                options.AddPolicy("IsCustomer", policy => policy.RequireClaim("CustomerRole", "customer"));
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = false;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}