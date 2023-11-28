using PokeCommon.API.Data;
using PokeCommon.API.Extensions;
using Pokemonisshoni;
using PokemonisshoniZ.ServiceDefaults;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddApplicationServices();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Init(app.Services);

app.Run();


void Init(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();

    var db = scope.ServiceProvider.GetService<PokeDBContext>();

    
   
}