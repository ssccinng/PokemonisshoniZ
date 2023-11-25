var builder = DistributedApplication.CreateBuilder(args);


var psthonkApi = builder.AddProject<Projects.PSThonk_API>("psthonk-api"); //.WithLaunchProfile("https");
var pkhomeApi = builder.AddProject<Projects.PokemonHome_API>("pokemonhome-api"); //.WithLaunchProfile("https");
var pokeocrApi = builder.AddProject<Projects.PokeOCR_API>("pokeocr.api");

builder.AddProject<Projects.PokemonisshoniZ>("pokemonisshoniz")
    .WithReference(psthonkApi)
    .WithReference(pkhomeApi)
    .WithReference(pokeocrApi)
    .WithLaunchProfile("https"); ;


var identityApi = builder.AddProject<Projects.Identity_API>("identity.api");








builder.Build().Run();
