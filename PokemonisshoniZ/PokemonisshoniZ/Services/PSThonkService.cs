using PokemonisshoniZ.Data;

namespace PokemonisshoniZ.Services
{
    public class PSThonkService(ApplicationDbContext dbContext)
    {
        public IEnumerable<PSUsername> GetPSUsernames(string userId) => dbContext.PSUsername.Where(x => x.UserId == userId);
    }
}
