using Microsoft.Extensions.Caching.Memory;
using PokemonisshoniZ.Components.PokemonShowdown;
using PokemonisshoniZ.Data;
using PokePSCore;
using PSThonk.Share.Models;
using System.Net.Http;

namespace PokemonisshoniZ.Services
{
    public class PSThonkService(HttpClient httpClient, IMemoryCache memoryCache)
    {
        //public IEnumerable<PSUsername> GetPSUsernames(string userId) => dbContext.PSUsername.Where(x => x.UserId == userId);

        private readonly string remoteServiceBaseUrl = "/api/v1/PsThonk/";
        private readonly string remotePsbattleServiceBaseUrl = "/api/v1/psbattles/";
        private readonly string remotePSPokemonServiceBaseUrl = "/api/v1/PSPokemons/";

        public Task<RankData[]> GetRankDatas(string id)
        {
            return httpClient.GetFromJsonAsync<RankData[]>($"{remoteServiceBaseUrl}GetPSUserRankData/{id}")!;
        }

        public Task<UserDetail> GetUserDetail(string id)
        {
            return httpClient.GetFromJsonAsync<UserDetail>($"{remoteServiceBaseUrl}GetPSUserDetail/{id}")!;
        }

        public Task<List<PSBattle>> GetNamePsBattle(string name)
        {
            return httpClient.GetFromJsonAsync<List<PSBattle>>($"{remotePsbattleServiceBaseUrl}youbattle/{name}/0")!;

        }

        public Task<PSBattle> GetPsBattle(string roomid)
        {
            return httpClient.GetFromJsonAsync<PSBattle>($"{remotePsbattleServiceBaseUrl}battlereplay/0?roomId={roomid}")!;

        }

        public async ValueTask<List<PSPokemon>> GetPSThonkPSPokemon()
        {
            if ( memoryCache.TryGetValue("PSthonk_PsPokemon", out var val))
            {
                return (List<PSPokemon>)val;
            }
            var res = await httpClient.GetFromJsonAsync<List<PSPokemon>>($"{remotePSPokemonServiceBaseUrl}")!;
            memoryCache.Set("PSthonk_PsPokemon", res);

            return res;
        }
    }
}
