using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonisshoniZ.Data;
using PokemonisshoniZ.Services;
using PSThonk.Share.Models;

namespace PokemonisshoniZ.Pages
{
    public class PsReplayModel(ApplicationDbContext dbContext, PokemonisshoniService pokemonisshoniService) : PageModel
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public PSBattle pSBattle;

        public async Task OnGet(string roomId)
        {
            pSBattle = await pokemonisshoniService.PSThonkService.GetPsBattle(roomId);

        }
    }
}
