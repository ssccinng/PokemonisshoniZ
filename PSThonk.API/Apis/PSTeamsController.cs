using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSThonk.API.Data;
using PSThonk.Share.Models;

namespace PSThonk.API.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class PSTeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PSTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PSTeams
        [HttpGet("{idx}")]
        public async Task<ActionResult<IEnumerable<PSTeam>>> GetPSTeams(int idx)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            return await _context.PSTeams.Where(s => s.TeamTime == dateTime).ToListAsync();
        }

        // GET: api/PSTeams
        //[HttpGet("{idx}")]
        //public async Task<ActionResult<IEnumerable<dynamic>>> GetPS1Teams(int idx)
        //{
        //    //DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
        //    //var res = _context
        //    //    .PSBattles
        //    //    .Include(s=>s.Player1Team)
        //    //    .Include(s=>s.Player2Team)
        //    //    .Where(s => s.BatteTime == dateTime);

        //    //var p1t = res
        //    //    .Select(s => new { s.Player1, s.Player1Team }); 
        //    //var p2t = res
        //    //    .Select(s => new { s.Player2, s.Player2Team });
        //    //p1t.ToList().AddRange(p2t.ToList());
        //    //var v = await (res
        //    //    .Select(s=> new { s.Player1, s.Player1Team})
        //    //    .ToList()
        //    //    .Concat(
        //    //        res
        //    //        .Select(s => new { s.Player2, s.Player2Team })
        //    //    )
        //    //    .ToListAsync());
        //}

        //// GET: api/PSTeams/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PSTeam>> GetPSTeam(int id)
        //{
        //    var pSTeam = await _context.PSTeams.FindAsync(id);

        //    if (pSTeam == null)
        //    {
        //        return NotFound();
        //    }

        //    return pSTeam;
        //}

        //// PUT: api/PSTeams/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPSTeam(int id, PSTeam pSTeam)
        //{
        //    if (id != pSTeam.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(pSTeam).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PSTeamExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/PSTeams
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PSTeam>> PostPSTeam(PSTeam pSTeam)
        //{
        //    _context.PSTeams.Add(pSTeam);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPSTeam", new { id = pSTeam.Id }, pSTeam);
        //}

        //// DELETE: api/PSTeams/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePSTeam(int id)
        //{
        //    var pSTeam = await _context.PSTeams.FindAsync(id);
        //    if (pSTeam == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PSTeams.Remove(pSTeam);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool PSTeamExists(int id)
        {
            return _context.PSTeams.Any(e => e.Id == id);
        }
    }
}
