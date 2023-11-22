using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using PokemonisshoniZ.Client.Models;

namespace PokemonisshoniZ.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{

    #region PS插件
    public DbSet<PSUsername> PSUsername { get; set; }
    #endregion
}
