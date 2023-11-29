using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeCommon.API.Data;
using PokeCommon.Models;
using PokeCommon.PokemonShowdownTools;
using PokeCommon.Utils;

namespace PokeCommon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PSTranslateController : ControllerBase
    {
        public PSTranslateController(PokeDBContext pokeDBContext)
        {
            PokemonTools.PokemonContext = pokeDBContext;
        }


        [HttpPost("PokeToPS")]
        public async Task<string> PokeToPS(GamePokemon gamePokemon)
        {
            return await PSConverter.ConvertToPsAsync(gamePokemon);
        }
        [HttpPost("PokeTeamToPS")]

        public async Task<string> PokeTeamToPS(GamePokemonTeam gamePokemon)
        {
            return await PSConverter.ConvertToPsAsync(gamePokemon);
        }

        [HttpPost("PSToPoke")]
        public async Task<GamePokemon> PSToPoke([FromBody]string text)
        {
            return await PSConverter.ConvertToPokemonAsync(text);
        }

        [HttpPost("PSToPokeTeam")]
        public async Task<GamePokemonTeam> PSToPokeTeam([FromBody] string text)
        {
            return await PSConverter.ConvertToPokemonsAsync(text);
        }
    }
}
