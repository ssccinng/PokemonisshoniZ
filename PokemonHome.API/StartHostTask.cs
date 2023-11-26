
using PokemonHome.API.Services;

namespace PokemonHome.API
{
    public class StartHostTask(HomeSerivce homeSerivce, ILogger<StartHostTask> logger) : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await homeSerivce.UpdateSession();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("PokemonHomeApi Stop...");
            return Task.CompletedTask;
            //throw new NotImplementedException();

        }
    }
}
