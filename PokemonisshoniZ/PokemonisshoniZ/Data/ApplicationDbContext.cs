using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
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


    #region 比赛
    public DbSet<PCLMatch> PCLMatches { get; set; }

    #region
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<PCLPokemon>().Property(e => e.Tags)
         .HasColumnType("json")
         .HasConversion(
         v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
         v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));

        builder.Entity<PokeTeam>().Property(e => e.Tags)
         .HasColumnType("json")
         .HasConversion(
         v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
         v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));


        builder.Entity<PokeTeam>().Property(e => e.PokemonIds)
         .HasColumnType("json")
         .HasConversion(
         v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
         v => JsonSerializer.Deserialize<int[]>(v, (JsonSerializerOptions)null));

        builder.Entity<PCLPokemonBox>().Property(e => e.PCLPokemonIds)
        .HasColumnType("json")
        .HasConversion(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
        v => JsonSerializer.Deserialize<long[]>(v, (JsonSerializerOptions)null));

        base.OnModelCreating(builder);
    }

}
