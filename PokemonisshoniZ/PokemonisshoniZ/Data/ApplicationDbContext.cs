using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using PokemonisshoniZ.Client.Models;

namespace PokemonisshoniZ.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{

    #region PS插件
    public DbSet<PSUsername> PSUsername { get; set; }
    #endregion

    #region 队伍
    public DbSet<PokeTeam> PokeTeams { get; set; }
    public DbSet<PCLPokemon> PCLPokemons { get; set; }
    public DbSet<PCLPokemonBox> PCLPokemonBoxes { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<PokeTeam>().OwnsOne(
        team => team.Tags, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToJson();
        });

        builder.Entity<PokeTeam>().OwnsOne(
       team => team.PokemonIds, ownedNavigationBuilder =>
       {
           ownedNavigationBuilder.ToJson();
       });


        builder.Entity<PCLPokemon>().OwnsOne(
       team => team.Tags, ownedNavigationBuilder =>
       {
           ownedNavigationBuilder.ToJson();
       });

        builder.Entity<PCLPokemonBox>().OwnsOne(
       team => team.PCLPokemonIds , ownedNavigationBuilder =>
       {
           ownedNavigationBuilder.ToJson();
       });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
