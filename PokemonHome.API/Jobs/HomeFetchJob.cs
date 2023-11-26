using PokemonHome.API.Services;
using Quartz;

namespace PokemonHome.API.Jobs
{
    public class HomeFetchJob(HomeSerivce homeSerivce, ILogger<HomeFetchJob> logger) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            logger.LogInformation($"{nameof(HomeFetchJob)} [{DateTime.Now:s}] 同步数据");
            await homeSerivce.UpdateSession();
            logger.LogInformation($"{nameof(HomeFetchJob)} [{DateTime.Now:s}] 同步数据完成");
        }

    }
}
