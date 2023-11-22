using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonisshoniZ.Data;

namespace PokemonisshoniZ.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PSUsernamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PSUsernamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PSUsernames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PSUsername>>> GetPSUsername()
        {
            return await _context.PSUsername.ToListAsync();
        }

        // GET: api/PSUsernames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PSUsername>> GetPSUsername(int id)
        {
            var pSUsername = await _context.PSUsername.FindAsync(id);

            if (pSUsername == null)
            {
                return NotFound();
            }

            return pSUsername;
        }

        // PUT: api/PSUsernames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPSUsername(int id, PSUsername pSUsername)
        {
            if (id != pSUsername.Id)
            {
                return BadRequest();
            }

            _context.Entry(pSUsername).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSUsernameExists(id))
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

        // POST: api/PSUsernames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PSUsername>> PostPSUsername(PSUsername pSUsername)
        {
            _context.PSUsername.Add(pSUsername);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPSUsername", new { id = pSUsername.Id }, pSUsername);
        }

        // DELETE: api/PSUsernames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePSUsername(int id)
        {
            var pSUsername = await _context.PSUsername.FindAsync(id);
            if (pSUsername == null)
            {
                return NotFound();
            }

            _context.PSUsername.Remove(pSUsername);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PSUsernameExists(int id)
        {
            return _context.PSUsername.Any(e => e.Id == id);
        }
    }
}
