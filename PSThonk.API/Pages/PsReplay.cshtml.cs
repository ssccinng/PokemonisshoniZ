using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PSThonk.API.Data;
using PSThonk.Share.Models;

namespace PSThonk.API.Pages
{
    public class PsReplayModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public PSBattle pSBattle;
        public PsReplayModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task OnGet(string roomId)
        {
            pSBattle = await _dbContext.PSBattles.FirstOrDefaultAsync(s => s.RoomId == roomId);

        }
    }
}
