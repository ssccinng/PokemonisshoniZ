using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PokeCommon.PokemonShowdownTools;
using PokemonisshoniZ.Components.PokemonShowdown;
using PokePSCore;
using PSThonk.API.Services;
using System.Text.Json;

namespace PSThonk.API.Apis
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PSThonkController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        public static PSClient Client { get; set; } = GetClient();
        public PSSerivce PSSerivce { get; }

        private static PSClient GetClient()
        {
            PSClient client = new("testtttt", "");
            client.ConnectAsync().Wait();
            return client;
        }

        public PSThonkController(IMemoryCache memoryCache, PSSerivce pSSerivce)
        {
            _memoryCache = memoryCache;
            PSSerivce = pSSerivce;
            Client.UserDetailsAction += async (msg) =>
            {
                var detail = JsonSerializer.Deserialize<UserDetail>(msg);

                _memoryCache.Set(detail.Id, detail, TimeSpan.FromSeconds(10));
            };
        }

        [HttpGet("GetPSUserRankData/{Id}")]
        public async Task<List<RankData>> GetRankDatasAsync(string Id)
        {
            //var userId = PSSerivce.IdentityService.GetUserIdentity();
            return await Client.GetRankAsync(Id);
        }

         
        [HttpGet("GetPSUserDetail/{Id}")]
        public async Task<IActionResult> GetUserDetail(string Id)
        {
            Id = PSUtils.GetPurePSId(Id);

            if (_memoryCache.TryGetValue(Id, out var userDetail))
            {
                return Ok(userDetail);
            }
            await Client.GetUserDetails(Id);

            for (int i = 0; i < 5; i++)
            {
                if (_memoryCache.TryGetValue(Id, out userDetail)) { return Ok(userDetail); }
                await Task.Delay(1000);
            }
            return Problem("获取信息失败...");
        }

    }
}
