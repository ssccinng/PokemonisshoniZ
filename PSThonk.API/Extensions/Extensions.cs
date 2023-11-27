using PokemonisshoniZ.ServiceDefaults;
using PSThonk.API.Infrastructure.Services;
using PSThonk.API.Services;

namespace PSThonk.API.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.AddDefaultAuthentication();


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
