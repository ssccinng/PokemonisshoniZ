using PokeCommon.API.Data;
using PokeCommon.API.Extensions;
using PokemonDataAccess.Models;
using Pokemonisshoni;
using PokemonisshoniZ.ServiceDefaults;
using PokeTeamImageTran;
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

Init(app.Services);

app.Run();


void Init(IServiceProvider serviceProvider)
{
    int id = 0;
    using var scope = serviceProvider.CreateScope();

    var db = scope.ServiceProvider.GetService<PokeDBContext>();

    var pk = JsonSerializer.Deserialize<List<PokeModel>>(File.ReadAllText("pokenameall.json"));


    var poke = db.Pokemons.ToList();
    var abs = db.Abilities.ToList();
    int ii = 0;

    id = poke.Max(s => s.Id);
    foreach (var pp in pk)
    {
        if (!poke.Any(s => s.NameEng == pp.Name_Eng))
        {
            ii++;
            if (ii > 2)
            {
                var fasdf = Pokemondata.GetPokemonBase((int)Pokemondata.EngPokemonID[pp.Name_Eng]);
                Console.WriteLine(pp.Name_Chs);
                Console.WriteLine(JsonSerializer.Serialize(Pokemondata.GetPokemonBase((int)Pokemondata.EngPokemonID[pp.Name_Eng]), new JsonSerializerOptions { WriteIndented = true}));
                int ffid = 0;
                foreach (var nn in fasdf.NameList)
                {
                    var sda = nn.Split("-");
                    var fname = nn;
                    if (sda.Length > 1)
                    {
                        fname = string.Join("-", sda[1..]);
                    }
                var ppp =  new Pokemon
                {
                    Ability1 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[fasdf.AbilityList[0]]),
                    Ability2 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[fasdf.AbilityList[1]]),
                    AbilityH = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[fasdf.AbilityList[2]]),
                    BaseHP = fasdf.RacialValue.Value[0],
                    BaseAtk = fasdf.RacialValue.Value[1],
                    BaseDef = fasdf.RacialValue.Value[2],
                    BaseSpa = fasdf.RacialValue.Value[3],
                    BaseSpd = fasdf.RacialValue.Value[4],
                    BaseSpe = fasdf.RacialValue.Value[5],
                     FullNameChs = nn,
                     FormNameChs = fname,
                     NameChs = pp.Name_Chs,
                     NameEng = pp.Name_Eng,
                     NameJpn = pp.Name_Jpn,
                     PokeFormId = ffid++,
                     Id = ++id,
                      
                };

                    db.Pokemons.Add(ppp);

                }

            }
        }
    }
    db.SaveChanges();
    return;

    var mv = JsonSerializer.Deserialize<List<PokeModel>>(File.ReadAllText("wazanameall.json"));
    id = db.Moves.Max(s => s.MoveId) + 1;
    var mvl = db.Moves.ToList();
    Pokemondata.MOVEDATA = Pokemondata.MOVEDATA.Where(s => s != null).ToArray();
    foreach (var move in mv)
    {
        if (!mvl.Any(s => s.Name_Eng == move.Name_Eng))
        {
            Console.WriteLine(Pokemondata.MOVEDATA.First(s => s.engname == move.Name_Eng).chiname);
            Console.WriteLine(Pokemondata.MOVEDATA.First(s => s.engname == move.Name_Eng).type);
            var c1c = Pokemondata.MOVEDATA.First(s => s.engname == move.Name_Eng).type;
            db.Moves.Add(new PokemonDataAccess.Models.Move
            {
                MoveId = id++,
                Name_Chs = move.Name_Chs,
                Name_Eng = move.Name_Eng,
                Name_Jpn = move.Name_Jpn,
                MoveType = db.PokeTypes.First( s=> s.Name_Chs == c1c),
                 Damage_Type = Pokemondata.MOVEDATA.First(s => s.engname == move.Name_Eng).atktype
            }); ;
        }
    }
    db.SaveChanges();
    return;

    var it = JsonSerializer.Deserialize<List<PokeModel>>(File.ReadAllText("itemnameall.json"));
    id = db.Items.Max(s => s.ItemId) + 1;
    foreach (var item in it)
    {
        if (!db.Items.Any(s => s.Name_Chs == item.Name_Chs))
        {
            db.Items.Add(new PokemonDataAccess.Models.Item
            {
                ItemId = id++,
                Name_Chs = item.Name_Chs,
                Name_Eng = item.Name_Eng,
                Name_Jpn = item.Name_Jpn,
            }); ;
        }
    }
    db.SaveChanges();
    return;
    var ab = JsonSerializer.Deserialize<List<PokeModel>>(File.ReadAllText("tokuseinameall.json"));
    id = db.Abilities.Max(s => s.AbilityId) + 1;
    foreach (var ability in ab)
    {
        if (!db.Abilities.Any(s => s.Name_Chs == ability.Name_Chs))
        {
            db.Abilities.Add(new PokemonDataAccess.Models.Ability
            {
                AbilityId = id++,
                Name_Chs = ability.Name_Chs,
                Name_Eng = ability.Name_Eng,
                Name_Jpn = ability.Name_Jpn,
            }); ;
        }
    }
    db.SaveChanges();

}