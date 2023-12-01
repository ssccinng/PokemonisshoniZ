using PokemonisshoniZ.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.IdentityModel.JsonWebTokens;
using PokemonisshoniZ.ServiceDefaults;
using Polly;
using Polly.Timeout;

namespace PokemonisshoniZ.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            // builder.AddAuthenticationServices();

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<Program>();
            });

            builder.Services.AddScoped<PokemonisshoniService>();

            builder.Services
                .AddHttpClient<PSThonkService>(o =>o.BaseAddress = new("http://psthonk-api"))
                .AddAuthToken();
            builder.Services
                .AddHttpClient<PokemonHomeService>(o => o.BaseAddress = new("http://pokemonhome-api"))
                .AddAuthToken(); 
            builder.Services
                .AddHttpClient<PokeCommonService>(o => o.BaseAddress = new("http://pokecommon-api"))
                .AddAuthToken();
            builder.Services
                .AddHttpClient<PokeOCRService>(o => { o.BaseAddress = new("http://pokeocr-api"); })
                .AddAuthToken()
                .AddStandardResilienceHandler(config =>
                {
                    TimeSpan timeSpan = TimeSpan.FromMinutes(2);
                    config.AttemptTimeout.Timeout = timeSpan;
                    config.CircuitBreaker.SamplingDuration = timeSpan * 2;
                    config.TotalRequestTimeout.Timeout = timeSpan * 3;
                });

        }

        public static void AddAuthenticationServices(this IHostApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var services = builder.Services;

            JsonWebTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            var identityUrl = configuration.GetRequiredValue("IdentityUrl");
            var callBackUrl = configuration.GetRequiredValue("CallBackUrl");
            var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

            // Add Authentication services
            services.AddAuthorization();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(options => options.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
            .AddOpenIdConnect(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = identityUrl;
                options.SignedOutRedirectUri = callBackUrl;
                options.ClientId = "webapp";
                options.ClientSecret = "secret";
                options.ResponseType = "code";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.RequireHttpsMetadata = false;
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("orders");
                options.Scope.Add("basket");
            });

            // Blazor auth services
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            services.AddCascadingAuthenticationState();
        }
    }


}
