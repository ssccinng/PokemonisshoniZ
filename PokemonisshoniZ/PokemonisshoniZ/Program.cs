using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PokemonisshoniZ.Client.Pages;
using PokemonisshoniZ.Client.Services;
using PokemonisshoniZ.Components;
using PokemonisshoniZ.Components.Account;
using PokemonisshoniZ.Data;
using Radzen;

using Serilog;
using Serilog.Sinks;
using Serilog.Formatting;
using Serilog.Events;
using PokemonisshoniZ.ServiceDefaults;
using PokemonisshoniZ.Extensions;
using System.Data;

namespace PokemonisshoniZ;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddControllers();

        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();


        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        });

        //builder.Services.AddHttpClient("BlazorApp2.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

        //builder.Services.AddHttpClient();
        builder.Services.AddScoped<PSPluginService>();


        builder.Services.AddRadzenComponents();

#if DEBUG
#else
        builder.WebHost.UseUrls("https://*:37799");

#endif



        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        //options.UseSqlServer(connectionString));


        builder.AddApplicationServices();


        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddServerSideBlazor().AddHubOptions(o =>
        {
            o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
        });
        //builder.Services.AddLogging(loggingBuilder =>
        //{
        //    loggingBuilder.AddSerilog();
        //});
        builder.Logging.AddSerilog();
        //builder.Logging.AddDebug();
        builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapControllers();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Counter).Assembly);

        // Add additional endpoints required by the Identity /Account Razor components.
        app.MapAdditionalIdentityEndpoints();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
               await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            var um = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            if (um == null)
            {
                throw new Exception("userManager null");

            }
            await um.AddToRoleAsync(await um.FindByEmailAsync("whs11998@163.com"), "Admin");

        }

        Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Debug()
      .WriteTo.File("logs/Pokemonisshoni.log", rollingInterval: RollingInterval.Day,
      outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level}] |{SourceContext}.{Method}| - {Message}{NewLine}{Exception}")
      .CreateLogger();

        app.Run();
    }
}
