using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
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
        public async Task<GamePokemon> PSToPoke(Pack text)
        {
             return await PSConverter.ConvertToPokemonAsync(text.Value);
        }

        [HttpPost("PSToPokeTeam")]
        public async Task<GamePokemonTeam> PSToPokeTeam(Pack text)
        {
            var res = await PSConverter.ConvertToPokemonsAsync(text.Value);
            while (res.GamePokemons.Count < 6)
            {
                res.GamePokemons.Add(new GamePokemon());
            }
            return res;
        }
    }

    public class Pack
    {
        public string Value { get; set; }
    }
}
