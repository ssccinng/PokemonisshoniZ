using PokemonHome.API.Jobs;
using PokemonHome.API.Services;
using Quartz;


namespace PokemonHome.API.Extenisons
{
    public static class Extenisons
    {
        public static void AddHomeServices(this IHostApplicationBuilder builder) 
        {

            builder.Services.AddHttpClient<HomeSerivce>(o => o.BaseAddress = new(""));
            builder.Services.AddSingleton<HomeSerivce>();

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<Program>();
            });

            builder.Services.AddQuartz(config =>
            {
                JobKey jobkey = JobKey.Create(nameof(HomeFetchJob));
                config.AddJob<HomeFetchJob>(jobkey).AddTrigger(trigger =>
                {
                    trigger.ForJob(jobkey);
                    trigger.WithCronSchedule("0 40 * * * ?");
                });
            });

            builder.Services.AddHostedService<StartHostTask>();

            builder.Services.AddQuartzHostedService(config =>
            {
                config.WaitForJobsToComplete = false;
            });
        }
    }
}
