using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeCommon.API.Data;
using PokemonDataAccess.Models;

namespace PokeCommon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PokeDataController(PokeDBContext pokeDBContext) : ControllerBase
    {
        [HttpGet("GetPokemons")]
        public IEnumerable<Pokemon> GetPokemons()
        {
            return pokeDBContext.Pokemons;
        }
        [HttpGet("GetPSPokemons")]
        public IEnumerable<PSPokemon> GetPSPokemons()
        {
            return pokeDBContext.PSPokemons;
        }


        [HttpGet("GetItems")]
        public IEnumerable<Item> GetItems()
        {
            return pokeDBContext.Items;
        }
        [HttpGet("GetMoves")]
        public IEnumerable<Move> GetMoves()
        {
            return pokeDBContext.Moves;
        }
        [HttpGet("GetAbilities")]
        public IEnumerable<Ability> GetAbilities()
        {
            return pokeDBContext.Abilities;
        }


        [HttpGet("GetPokeTypes")]
        public IEnumerable<PokeType> GetPokeTypes()
        {
            return pokeDBContext.PokeTypes;
        }


        [HttpGet("GetNatures")]
        public IEnumerable<Nature> GetNatures()
        {
            return pokeDBContext.Natures.Include(s => s.Stat_Down).Include(s => s.Stat_Up).ToList();
        }



    }
}
