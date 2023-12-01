using Microsoft.EntityFrameworkCore;
using PokemonisshoniZ.ServiceDefaults;
using PSThonk.API.Data;
using PSThonk.API.Infrastructure.Services;
using PSThonk.API.Services;

namespace PSThonk.API.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            //builder.AddDefaultAuthentication();


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IIdentityService, IdentityService>();
            builder.Services.AddSingleton<PSSerivce>();

            builder.Services.AddMediatR(option =>
            {
                option.RegisterServicesFromAssemblyContaining<Program>();
            });
        }
    }
}
