using PokeCommon.Models;
using System.Net.Http.Json;

namespace PokemonisshoniZ.Services
{
    public class PokemonHomeService(HttpClient httpClient)
    {
        private readonly string remoteServiceBaseUrl = "/api/v1/PKHome/";

        public  Task<SVPokemonHomeSession[]> GetPokemonHomeSessions()
        {
            return httpClient.GetFromJsonAsync<SVPokemonHomeSession[]>($"{remoteServiceBaseUrl}Sessions")!;
        }

        public Task<SVPokemonHomeTrainerRankData[]> GetHomeTrainerRankDatas(string sessionId)
        {
            return httpClient.GetFromJsonAsync<SVPokemonHomeTrainerRankData[]>($"{remoteServiceBaseUrl}TrainersRankData/{sessionId}")!;
        }
    }
}
