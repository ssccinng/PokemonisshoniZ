using PokeCommon.Models;
using PokemonDataAccess.Models;

namespace PokemonisshoniZ.Services
{
    public class PokeCommonService(HttpClient httpClient)
    {
        private readonly string remotePSTranslateServiceBaseUrl = "/api/v1/PSTranslate/";
        private readonly string remotePokeDataServiceBaseUrl = "/api/v1/PokeData/";

        public string PokeToPS(GamePokemon gamePokemon)
        {
            throw new NotImplementedException();
        }

        public string PokeTeamToPS(GamePokemonTeam gamePokemon)
        {
            throw new NotImplementedException();
        }

        public async Task<GamePokemon> PSToPoke(string text)
        {
            return await (await httpClient.PostAsync($"{remotePSTranslateServiceBaseUrl}PSToPoke", new StringContent(text))).Content.ReadFromJsonAsync<GamePokemon>();
        }

        public GamePokemonTeam PSToPokeTeam(string text)
        {
            throw new NotImplementedException();


        }


        public Task<Pokemon[]> GetPokemons()
        {
            // 撕烤缓存
            return httpClient.GetFromJsonAsync<Pokemon[]>($"{remotePokeDataServiceBaseUrl}GetPokemons");
        }
    }
}
