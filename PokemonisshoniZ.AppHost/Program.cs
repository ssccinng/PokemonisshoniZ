var builder = DistributedApplication.CreateBuilder(args);

//var redis = builder.AddRedisContainer("redis");


var psthonkApi = builder.AddProject<Projects.PSThonk_API>("psthonk-api"); //.WithLaunchProfile("https");
var pkhomeApi = builder.AddProject<Projects.PokemonHome_API>("pokemonhome-api"); //.WithLaunchProfile("https");
var pokeocrApi = builder.AddProject<Projects.PokeOCR_API>("pokeocr.api");

var webApp = builder.AddProject<Projects.PokemonisshoniZ>("webapp")
    .WithReference(psthonkApi)
    .WithReference(pkhomeApi)
    .WithReference(pokeocrApi)
    .WithLaunchProfile("https"); ;

webApp.WithEnvironmentForServiceBinding("IdentityUrl", webApp);

var identityApi = builder.AddProject<Projects.Identity_API>("identity.api");



webApp.WithEnvironmentForServiceBinding("CallBackUrl", webApp, bindingName: "https");





builder.Build().Run();
