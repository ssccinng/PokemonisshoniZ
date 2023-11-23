using System.Net.Http.Json;

namespace PokemonisshoniZ.Client.Services
{
    public class PSPluginService(HttpClient httpClient)
    {
        public async Task<object[]> GetAllPsUser()
        {
            return await httpClient.GetFromJsonAsync<object[]>("/api/PSUsernames");
        }
    }
}
