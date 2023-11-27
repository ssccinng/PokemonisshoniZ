using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using PSThonk.API.Data;
using PSThonk.Share.Models;


namespace PSThonk.API.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PSPokemonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PSPokemonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PSPokemons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PSPokemon>>> GetPSPokemons()
        {
            //var aa = await _context.PSPokemons.ToListAsync();
            //foreach (var item in aa)
            //{
            //    try
            //    {
            //        item.PSChsName = Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(item.PSName)).name;

            //    }
            //    catch (Exception)
            //    {
            //        await Console.Out.WriteLineAsync(item.PSName);
            //        //throw;
            //    }
            //}
            ////var aa = _context.PSBattles.ToList();
            ////aa.ForEach(s => s.BatteTimeDetail = s.BatteTime);
            //_context.SaveChanges();
            return await _context.PSPokemons.ToListAsync();
        }

        // GET: api/PSPokemons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PSPokemon>> GetPSPokemon(int id)
        {
            var pSPokemon = await _context.PSPokemons.FindAsync(id);

            if (pSPokemon == null)
            {
                return NotFound();
            }

            return pSPokemon;
        }

        // PUT: api/PSPokemons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPSPokemon(int id, PSPokemon pSPokemon)
        {
            if (id != pSPokemon.Id)
            {
                return BadRequest();
            }

            _context.Entry(pSPokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSPokemonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PSPokemons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PSPokemon>> PostPSPokemon(PSPokemon pSPokemon)
        {
            _context.PSPokemons.Add(pSPokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPSPokemon", new { id = pSPokemon.Id }, pSPokemon);
        }

        // DELETE: api/PSPokemons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePSPokemon(int id)
        {
            var pSPokemon = await _context.PSPokemons.FindAsync(id);
            if (pSPokemon == null)
            {
                return NotFound();
            }

            _context.PSPokemons.Remove(pSPokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PSPokemonExists(int id)
        {
            return _context.PSPokemons.Any(e => e.Id == id);
        }
    }
}
