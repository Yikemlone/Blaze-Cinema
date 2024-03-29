using Cinema.DataAccess.Services.AuthorizeServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace Cinema.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddOptions();

            builder.Services.AddAuthorizationCore(options => {
                options.AddPolicy("IsAdmin", policy => policy.RequireClaim("AdminRole", "admin"));
                options.AddPolicy("IsManager", policy => policy.RequireClaim("ManagerRole", "manager"));
                options.AddPolicy("IsCustomer", policy => policy.RequireClaim("CustomerRole", "customer"));
            });

            builder.Services.AddScoped<IdentityAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthorizeApi, AuthorizeApi>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Adding MudBlazor
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}