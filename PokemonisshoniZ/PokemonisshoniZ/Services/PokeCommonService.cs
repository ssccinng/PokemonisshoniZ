using PokeCommon.Models;
using PokemonDataAccess.Models;
using System.Text.Json;

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
            var aa = (await httpClient.PostAsJsonAsync($"{remotePSTranslateServiceBaseUrl}PSToPoke", new { Value = text }));
            
            var cc = await aa.Content.ReadFromJsonAsync<GamePokemon>();

            //var gg = JsonSerializer.Deserialize<GamePokemon>(cc, new JsonSerializerOptions {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }); ;
            return cc;
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

        public Task<PSPokemon[]> GetPSPokemons()
        {
            // 撕烤缓存
            return httpClient.GetFromJsonAsync<PSPokemon[]>($"{remotePokeDataServiceBaseUrl}GetPSPokemons");
        }
    }
}
