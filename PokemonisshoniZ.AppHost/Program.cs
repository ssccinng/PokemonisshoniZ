var builder = DistributedApplication.CreateBuilder(args);

//var redis = builder.AddRedisContainer("redis");

var pokeIdentityApi = builder.AddProject<Projects.PokeIdentity_API>("pokeidentity.api");


var psthonkApi = builder.AddProject<Projects.PSThonk_API>("psthonk-api")
    .WithEnvironmentForServiceBinding("Identity__Url", pokeIdentityApi); //.WithLaunchProfile("https");
var pkhomeApi = builder.AddProject<Projects.PokemonHome_API>("pokemonhome-api")
    .WithEnvironmentForServiceBinding("Identity__Url", pokeIdentityApi); //.WithLaunchProfile("https");
var pokeocrApi = builder.AddProject<Projects.PokeOCR_API>("pokeocr-api")
    .WithEnvironmentForServiceBinding("Identity__Url", pokeIdentityApi);


var webApp = builder.AddProject<Projects.PokemonisshoniZ>("webapp")
    .WithReference(psthonkApi)
    .WithReference(pkhomeApi)
    .WithReference(pokeocrApi)
    .WithEnvironmentForServiceBinding("IdentityUrl", pokeIdentityApi)
    .WithLaunchProfile("https"); 

webApp.WithEnvironmentForServiceBinding("IdentityUrl", pokeIdentityApi);


pokeIdentityApi.WithEnvironmentForServiceBinding("PSThonkApiClient", psthonkApi)
           .WithEnvironmentForServiceBinding("PKHomeApiClient", pkhomeApi)
           .WithEnvironmentForServiceBinding("PokeOcrClient", pokeocrApi)
           .WithEnvironmentForServiceBinding("WebAppClient", webApp, bindingName: "https");

var identityApi = builder.AddProject<Projects.Identity_API>("identity.api");



webApp.WithEnvironmentForServiceBinding("CallBackUrl", webApp, bindingName: "https");










builder.Build().Run();
