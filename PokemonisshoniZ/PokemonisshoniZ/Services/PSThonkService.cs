using PokemonisshoniZ.Components.PokemonShowdown;
using PokemonisshoniZ.Data;
using PokePSCore;
using System.Net.Http;

namespace PokemonisshoniZ.Services
{
    public class PSThonkService(HttpClient httpClient)
    {
        //public IEnumerable<PSUsername> GetPSUsernames(string userId) => dbContext.PSUsername.Where(x => x.UserId == userId);

        private readonly string remoteServiceBaseUrl = "/api/v1/PsThonk/";

        public Task<RankData[]> GetRankDatas(string id)
        {
            return httpClient.GetFromJsonAsync<RankData[]>($"{remoteServiceBaseUrl}GetPSUserRankData/{id}")!;
        }

        public Task<UserDetail> GetUserDetail(string id)
        {
            return httpClient.GetFromJsonAsync<UserDetail>($"{remoteServiceBaseUrl}GetPSUserDetail/{id}")!;
        }
    }
}
