using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSThonk.API.Data;

using PSThonk.Share.Models;

namespace PSThonk.API.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PSBattlesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PSBattlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PSBattles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PSBattle>>> GetPSBattles()
        {
            return await _context.PSBattles.Include(s => s.Player1Team)
                .Include(s => s.Player2Team).ToListAsync();
        }

        [HttpGet("fitteam/{idx}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetfitPSBattles(int idx)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            var usrlist = _context.PSUserNames.Select(s => s.Name).ToList();
            var res = _context
                .PSBattles
                .Include(s => s.Player1Team)
                .Include(s => s.Player2Team)
                .Where(s => s.BatteTime == dateTime);

            var resa = res
                .Select(s => new { Player = s.Player1, s.Player1Team.pokemonids, res = s.WhoWin == BattlePlayer.Player1, Score = s.Player1Score })
                .Where(s => s.Score >= 1500)
                .ToList()
                .Concat(
                    res
                    .Select(s => new { Player = s.Player2, s.Player2Team.pokemonids, res = s.WhoWin == BattlePlayer.Player2, Score = s.Player2Score })
                    .Where(s => s.Score >= 1500)

                    .ToList()
                )
                //.Where(s => !usrlist.Contains(s.Player))
                .Where(s => !usrlist.Contains(Regex.Replace(s.Player, @"[^A-Za-z0-9]", "").ToLower()))
                .GroupBy(s => string.Join(',', s.pokemonids),
                    (age, s) => new
                    {
                        s.First().pokemonids,
                        Win = s.Count(pet => pet.res),
                        Lose = s.Count(pet => !pet.res),
                        Score = s.Max(pet => pet.Score),
                    }
                )
                .OrderByDescending(s => s.Score)
                .ToList();


            return resa;
        }
        [HttpGet("GetRangeTeam")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetRangeTeam([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            Console.WriteLine(start);
            Console.WriteLine(end);

            var usrlist = _context.PSUserNames.Select(s => s.Name).ToList();
            var res = _context
                .PSBattles
                .Include(s => s.Player1Team)
                .Include(s => s.Player2Team)
                .Where(s => s.BatteTimeDetail >= start && s.BatteTimeDetail < end.AddDays(1));

            var resa = res
                .Select(s => new { Player = s.Player1, s.Player1Team.pokemonids, res = s.WhoWin == BattlePlayer.Player1, Score = s.Player1Score })
                .Where(s => s.Score >= 1500)
                .ToList()
                .Concat(
                    res
                    .Select(s => new { Player = s.Player2, s.Player2Team.pokemonids, res = s.WhoWin == BattlePlayer.Player2, Score = s.Player2Score })
                    .Where(s => s.Score >= 1500)

                    .ToList()
                )
                //.Where(s => !usrlist.Contains(s.Player))
                .Where(s => !usrlist.Contains(Regex.Replace(s.Player, @"[^A-Za-z0-9]", "").ToLower()))
                .GroupBy(s => string.Join(',', s.pokemonids),
                    (age, s) => new
                    {
                        s.First().pokemonids,
                        Win = s.Count(pet => pet.res),
                        Lose = s.Count(pet => !pet.res),
                        Score = s.Max(pet => pet.Score),
                    }
                )
                .OrderByDescending(s => s.Score)
                .ToList();


            return resa;
            return Ok();
        }
        [HttpGet("GetRangePoke")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetRangePoke([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            //DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            var usrlist = _context.PSUserNames.Select(s => s.Name).ToList();
            var res = _context
                .PSBattles
                .Include(s => s.Player1Team)
                .Include(s => s.Player2Team)
                .Where(s => s.BatteTimeDetail >= start && s.BatteTimeDetail < end.AddDays(1));

            var resa = res
                .Select(s => new { Player = s.Player1, s.Player1Team.pokemonids, res = s.WhoWin == BattlePlayer.Player1, Score = s.Player1Score })
                .ToList()
                .Concat(
                    res
                    .Select(s => new { Player = s.Player2, s.Player2Team.pokemonids, res = s.WhoWin == BattlePlayer.Player2, Score = s.Player2Score })
                    .ToList()
                )
                .Where(s => !usrlist.Contains(Regex.Replace(s.Player, @"[^A-Za-z0-9]", "").ToLower()))

                //.Where(s => !usrlist.Contains(s.Player))
                .ToList();
            List<int> pokeids = new List<int>();
            for (int i = 0; i < resa.Count; ++i)
            {
                for (int j = 0; j < resa[i].pokemonids.Count; ++j)
                {
                    if (resa[i].pokemonids[j] != 0)
                    {
                        pokeids.Add(resa[i].pokemonids[j]);
                    }
                }
            }
            var resb = pokeids
                .GroupBy(s => s, (id, list) => new { pokeId = id, cnt = list.Count() })
                .OrderByDescending(s => s.cnt)
                .Take(50)
                .ToList();

            return resb;
        }

        [HttpGet("fitpoke/{idx}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetfitPSPoke(int idx)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            var usrlist = _context.PSUserNames.Select(s => s.Name).ToList();
            var res = _context
                .PSBattles
                .Include(s => s.Player1Team)
                .Include(s => s.Player2Team)
                .Where(s => s.BatteTime == dateTime);

            var resa = res
                .Select(s => new { Player = s.Player1, s.Player1Team.pokemonids, res = s.WhoWin == BattlePlayer.Player1, Score = s.Player1Score })
                .ToList()
                .Concat(
                    res
                    .Select(s => new { Player = s.Player2, s.Player2Team.pokemonids, res = s.WhoWin == BattlePlayer.Player2, Score = s.Player2Score })
                    .ToList()
                )
                .Where(s => !usrlist.Contains(Regex.Replace(s.Player, @"[^A-Za-z0-9]", "").ToLower()))

                //.Where(s => !usrlist.Contains(s.Player))
                .ToList();
            List<int> pokeids = new List<int>();
            for (int i = 0; i < resa.Count; ++i)
            {
                for (int j = 0; j < resa[i].pokemonids.Count; ++j)
                {
                    if (resa[i].pokemonids[j] != 0)
                    {
                        pokeids.Add(resa[i].pokemonids[j]);
                    }
                }
            }
            var resb = pokeids
                .GroupBy(s => s, (id, list) => new { pokeId = id, cnt = list.Count() })
                .OrderByDescending(s => s.cnt)
                .Take(50)
                .ToList();

            return resb;
        }
        [HttpGet("mybattle")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PSBattle>>> GetMyPSBattles()
        {
            //??? 卧槽???
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return null;
            //var usernames = _context.Users
            //    .Include(s => s.PSUserNames)
            //    .SingleOrDefault(s => s.Id == userId)
            //    .PSUserNames
            //    .Select(s => s.Name);
            ////到时这里去掉replay
            //return await _context.PSBattles
            //    .Include(s => s.Player1Team)
            //    .Include(s => s.Player2Team)
            //    .Where(s => usernames.Contains(Regex.Replace(s.Player1, @"[^A-Za-z0-9]", "").ToLower()) || usernames.Contains(Regex.Replace(s.Player2, @"[^A-Za-z0-9]", "").ToLower()))
            //    .ToListAsync();
        }
        [HttpGet("mybattle/{idx}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PSBattle>>> GetMyPSBattles(int idx)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return null;
            //var usernames = _context.Users
            //    .Include(s => s.PSUserNames)
            //    .SingleOrDefault(s => s.Id == userId)
            //    .PSUserNames
            //    .Select(s => s.Name);
            ////到时这里去掉replay
            //var res = _context.PSBattles
            //    .Include(s => s.Player1Team)
            //    .Include(s => s.Player2Team)
            //    .Where(s => s.BatteTime == dateTime)
            //    .ToList()
            //    //.Where(s => usernames.Contains(s.Player1) || usernames.Contains(s.Player2))
            //    .Where(s => usernames.Contains(Regex.Replace(s.Player1, @"[^A-Za-z0-9]", "").ToLower()) || usernames.Contains(Regex.Replace(s.Player2, @"[^A-Za-z0-9]", "").ToLower()))

            //    .ToList();
            //res.ForEach(s => s.BattleReplay = null);
            //return res;
        }

        [HttpGet("myRangebattle")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PSBattle>>> GetMyRangePSBattles([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            //DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return null;
            //var usernames = _context.Users
            //    .Include(s => s.PSUserNames)
            //    .SingleOrDefault(s => s.Id == userId)
            //    .PSUserNames
            //    .Select(s => s.Name);
            ////到时这里去掉replay
            //var res = _context.PSBattles
            //    .Include(s => s.Player1Team)
            //    .Include(s => s.Player2Team)
            //    //.Where(s => s.BatteTime == dateTime)
            //    .Where(s => s.BatteTimeDetail >= start && s.BatteTimeDetail < end.AddDays(1))

            //    .ToList()
            //    //.Where(s => usernames.Contains(s.Player1) || usernames.Contains(s.Player2))
            //    .Where(s => usernames.Contains(Regex.Replace(s.Player1, @"[^A-Za-z0-9]", "").ToLower()) || usernames.Contains(Regex.Replace(s.Player2, @"[^A-Za-z0-9]", "").ToLower()))

            //    .ToList();
            //res.ForEach(s => s.BattleReplay = null);
            //return res;
        }

        [HttpGet("youbattle/{name}/{idx}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PSBattle>>> GetYouPSBattles(string name, int idx)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            //到时这里去掉replay
            var res = _context.PSBattles
                .Include(s => s.Player1Team)
                .Include(s => s.Player2Team)
                .Where(s => s.Player1.Contains(name) || s.Player2.Contains(name));
            //.Where(s => s.Player1.Contains(name) || s.Player2.Contains(name));

            if (idx != -999)
            {
                res = res.Where(s => s.BatteTime == dateTime);
            }
            var re = await res.ToListAsync();
            re.ForEach(s => s.BattleReplay = null);
            return re;
        }

        [HttpGet("youbattleHeader/{name}/{idx}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PSBattle>>> GetYouPSBattles1(string name, int idx)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            //到时这里去掉replay
            var res = _context.PSBattles
                .Include(s => s.Player1Team)
                .Include(s => s.Player2Team)
                .Where(s => s.Header1.Contains(name) || s.Header2.Contains(name));
            //.Where(s => s.Player1.Contains(name) || s.Player2.Contains(name));

            if (idx != -999)
            {
                res = res.Where(s => s.BatteTime == dateTime);
            }
            var re = await res.ToListAsync();
            re.ForEach(s => s.BattleReplay = null);
            return re;
        }

        [HttpGet("allbattle/{idx}")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllPSBattles(int idx)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(7 * idx);
            var usrlist = _context.PSUserNames.Select(s => s.Name).ToList();
            IQueryable<PSBattle> res = _context
                .PSBattles
                .Include(s => s.Player1Team)
                .Include(s => s.Player2Team);
            if (idx != -999)
                res = res
                .Where(s => s.BatteTime == dateTime);

            var resa = res
                .Select(s => new { Player = s.Player1, s.Player1Team.pokemonids, res = s.WhoWin == BattlePlayer.Player1, Score = s.Player1Score })
                .ToList()
                .Concat(
                    res
                    .Select(s => new { Player = s.Player2, s.Player2Team.pokemonids, res = s.WhoWin == BattlePlayer.Player2, Score = s.Player2Score })
                    .ToList()
                )
                .Where(s => !usrlist.Contains(s.Player)).ToList()
                .GroupBy(s => string.Join(',', s.pokemonids),
                    (age, s) => new
                    {
                        s.First().pokemonids,
                        player = s.Select(pet => pet.Player).GroupBy(s => s, (a, b) => new { player = a, cnt = b.Count() })
                    }
                )
                .ToList();
            return resa;
        }
        // GET: api/PSBattles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PSBattle>> GetPSBattle(int id)
        {
            var pSBattle = await _context.PSBattles.FindAsync(id);

            if (pSBattle == null)
            {
                return NotFound();
            }

            return pSBattle;
        }
        [HttpGet("battlereplay/{id}")]
        public async Task<ActionResult<PSBattle>> GetRoomPSBattle(string roomId)
        {
            var pSBattle = await _context.PSBattles.FirstOrDefaultAsync(s => s.RoomId == roomId);

            if (pSBattle == null)
            {
                return NotFound();
            }

            return pSBattle;
        }

        // PUT: api/PSBattles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPSBattle(int id, PSBattle pSBattle)
        {
            if (id != pSBattle.Id)
            {
                return BadRequest();
            }

            _context.Entry(pSBattle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSBattleExists(id))
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

        // POST: api/PSBattles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PSBattle>> PostPSBattle(PSBattle pSBattle)
        {
            _context.PSBattles.Add(pSBattle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPSBattle", new { id = pSBattle.Id }, pSBattle);
        }

        // DELETE: api/PSBattles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePSBattle(int id)
        {
            var pSBattle = await _context.PSBattles.FindAsync(id);
            if (pSBattle == null)
            {
                return NotFound();
            }

            _context.PSBattles.Remove(pSBattle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PSBattleExists(int id)
        {
            return _context.PSBattles.Any(e => e.Id == id);
        }
    }
}
