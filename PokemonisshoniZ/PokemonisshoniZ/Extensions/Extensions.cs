using PokemonisshoniZ.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.IdentityModel.JsonWebTokens;
using PokemonisshoniZ.ServiceDefaults;

namespace PokemonisshoniZ.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services
                .AddHttpClient<PSThonkService>(o =>o.BaseAddress = new("http://psthonk-api"))
                .AddAuthToken();
            builder.Services
                .AddHttpClient<PokemonHomeService>(o => o.BaseAddress = new("http://PokemonHome-api"))
                .AddAuthToken();
        }
    }
}
