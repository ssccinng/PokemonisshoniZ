var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PokemonisshoniZ>("pokemonisshoniz");

builder.Build().Run();
