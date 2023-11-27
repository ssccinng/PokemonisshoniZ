
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSThonk.API.Data;
using PSThonk.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSThonk.API.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public VersionController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<object>> GetVersion() =>
             new { version = $"{_context.VersionD.OrderByDescending(s => s.Id).First().VersionIdx:0.0}" };


        [HttpGet("/LastVersion")]
        public async Task<ActionResult<VersionD>> GetVersionL() =>
             _context.VersionD.OrderByDescending(s => s.Id).First();

        //[HttpGet("/ThonkTest")]
        //public async Task TTT()
        //{
        //    //return;
        //    var aa = _context.PSBattles.Include(s => s.Player1Team).Include(s => s.Player2Team).ToList();
        //    for (int i = 0; i < aa.Count; i++)
        //    {
        //        var item = aa[i];
        //        Console.WriteLine(item.RoomId);
        //        if (!item.IsBo3)
        //        {
        //            PSReplayThonk.Thonk2(item.BattleReplay.Split("\n"), _context, ref item);

        //        }
        //    }
        //    await _context.SaveChangesAsync();
        //}

    }
}
