using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
}
}
