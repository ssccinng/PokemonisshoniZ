var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PokemonisshoniZ>("pokemonisshoniz").WithLaunchProfile("https"); ;

builder.AddProject<Projects.PSThonk_API>("psthonk.api").WithLaunchProfile("https");

builder.Build().Run();
