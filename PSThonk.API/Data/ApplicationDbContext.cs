
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PSThonk.Share.Models;

namespace PSThonk.API.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<PSBattle> PSBattles { get; set; }
        public DbSet<PSTeam> PSTeams { get; set; }
        public DbSet<PSPokemon> PSPokemons { get; set; }
        public DbSet<PSUserName> PSUserNames { get; set; }
        public DbSet<VersionD> VersionD { get; set; }
    }
}
