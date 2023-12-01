using PokemonisshoniZ.Components.PokemonShowdown;
using PokemonisshoniZ.Data;
using PokePSCore;
using PSThonk.Share.Models;
using System.Net.Http;

namespace PokemonisshoniZ.Services
{
    public class PSThonkService(HttpClient httpClient)
    {
        //public IEnumerable<PSUsername> GetPSUsernames(string userId) => dbContext.PSUsername.Where(x => x.UserId == userId);

        private readonly string remoteServiceBaseUrl = "/api/v1/PsThonk/";
        private readonly string remotePsbattleServiceBaseUrl = "/api/v1/psbattles/";

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
    }
}
