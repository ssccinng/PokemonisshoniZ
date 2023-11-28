using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeCommon.Models;
using PokeCommon.PokemonShowdownTools;

namespace PokeCommon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PSTranslateController : ControllerBase
    {
        [HttpGet]
        public async Task<string> PokeToPS(GamePokemon gamePokemon)
        {
            return await PSConverter.ConvertToPsAsync(gamePokemon);
        }

        public async Task<string> PokeTeamToPS(GamePokemonTeam gamePokemon)
        {
            return await PSConverter.ConvertToPsAsync(gamePokemon);
        }
    }
}
