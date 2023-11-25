using MediatR;
using PokePSCore;
using PSThonk.API.Infrastructure.Services;
using System.Net.Http.Json;

namespace PSThonk.API.Services
{
    public class PSSerivce(IMediator mediator, IIdentityService identityService, ILogger<PSSerivce> logger)
    {
        //private readonly string remoteServiceBaseUrl = "/api/v1/PsThonk/";

        //public Task<RankData[]> GetRankDatas(string id)
        //{
        //    return httpClient.GetFromJsonAsync<RankData[]>($"{remoteServiceBaseUrl}/GetPSUserData/{id}")!;
        //}
        public IMediator Mediator { get; } = mediator;
        public IIdentityService IdentityService { get; } = identityService;
        public ILogger<PSSerivce> Logger { get; } = logger;
    }
}
