using PokeCommon.Models;
using PokemonDataAccess.Models;
using System.Text.Json;

namespace PokemonisshoniZ.Services
{
    public class PokeCommonService(HttpClient httpClient)
    {


        private readonly string remotePSTranslateServiceBaseUrl = "/api/v1/PSTranslate/";
        private readonly string remotePokeDataServiceBaseUrl = "/api/v1/PokeData/";

        public async Task<string> PokeToPS(GamePokemon gamePokemon)
        {
           return await (await httpClient.PostAsJsonAsync($"{remotePSTranslateServiceBaseUrl}PokeToPs", gamePokemon)).Content.ReadAsStringAsync();
        }

        public async Task<string> PokeTeamToPS(GamePokemonTeam gamePokemon)
        {
            return await (await httpClient.PostAsJsonAsync($"{remotePSTranslateServiceBaseUrl}PokeTeamToPs", gamePokemon)).Content.ReadAsStringAsync();
        }

        public async Task<GamePokemon> PSToPoke(string text)
        {
            var aa = (await httpClient.PostAsJsonAsync($"{remotePSTranslateServiceBaseUrl}PSToPoke", new { Value = text }));
            
            var cc = await aa.Content.ReadFromJsonAsync<GamePokemon>();

            //var gg = JsonSerializer.Deserialize<GamePokemon>(cc, new JsonSerializerOptions {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }); ;
            return cc;
        }

        public async Task<GamePokemonTeam> PSToPokeTeam(string text)
        {
            var aa = (await httpClient.PostAsJsonAsync($"{remotePSTranslateServiceBaseUrl}PSToPokeTeam", new { Value = text }));

            var cc = await aa.Content.ReadFromJsonAsync<GamePokemonTeam>();
            foreach (var c in cc.GamePokemons)
            {
                // todo: 暂时的
                if (c.Nature == null) c.Nature = Utils.Utils.Natures[0];
            }
            //var gg = JsonSerializer.Deserialize<GamePokemon>(cc, new JsonSerializerOptions {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }); ;
            return cc;


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


        public Task<Item[]> GetItems()
        {
            return httpClient.GetFromJsonAsync<Item[]>($"{remotePokeDataServiceBaseUrl}GetItems");
        }

        public Task<Move[]> GetMoves()
        {
            return httpClient.GetFromJsonAsync<Move[]>($"{remotePokeDataServiceBaseUrl}GetMoves");

        }

        public Task<Ability[]> GetAbilities()
        {
            return httpClient.GetFromJsonAsync<Ability[]>($"{remotePokeDataServiceBaseUrl}GetAbilities");

        }

        public Task<PokeType[]> GetPokeTypes()
        {
            return httpClient.GetFromJsonAsync<PokeType[]>($"{remotePokeDataServiceBaseUrl}GetPokeTypes");

        }

        public Task<Nature[]> GetNatures()
        {
            return httpClient.GetFromJsonAsync<Nature[]>($"{remotePokeDataServiceBaseUrl}GetNatures");

        }
        // 转换一下 
    }
}
