using PokemonHome.API.Services;
using Quartz;


namespace PokemonHome.API.Extenisons
{
    public static class Extenisons
    {
        public static void AddHomeServices(IHostApplicationBuilder builder) 
        {
            builder.Services.AddSingleton<HomeSerivce>();

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<Program>();
            });

            builder.Services.AddQuartzHostedService(config =>
            {
                config.WaitForJobsToComplete = false;
            });
        }
    }
}
