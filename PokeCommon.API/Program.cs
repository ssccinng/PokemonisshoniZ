using PokeCommon.API.Data;
using PokeCommon.API.Extensions;
using PokeCommon.Utils;
using PokemonDataAccess.Models;
using Pokemonisshoni;
using PokemonisshoniZ.ServiceDefaults;
using PokeTeamImageTran;
using System.Text.Json;
using System.Xml.Linq;

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
    // 这个有问题 撕烤
    PokemonTools.PokemonContext = db;

    return;

    var pss = db.PSPokemons.ToArray();
    var poke = db.Pokemons.ToList();

    //    foreach (var pspoke in pss)
    //{
    //    if (pspoke.PSChsName.EndsWith("-超极巨"))
    //    {
    //        pspoke.PSChsName = pspoke.PSChsName.Replace("-超极巨", "-超极巨化");

    //    }
    //}
    //db.SaveChanges();
    //return;

    foreach (var pspoke in pss)
    {
        var pokemon = poke.FirstOrDefault(s => s.FullNameChs == pspoke.PSChsName);
        if (pokemon != null)
        {
            //Console.WriteLine("{0} - {1}", pokemon.FullNameChs, pspoke.PSChsName);
            //pspoke.PokemonId = pokemon.Id;
        }
        else
        {

            if (pspoke.PSChsName.Contains("阿尔") || pspoke.PSChsName.Contains("银伴"))
            {
                continue;
            }
            Console.WriteLine("{0}", pspoke.PSChsName);

        }
    }
    db.SaveChanges();
    return;


    var pk = JsonSerializer.Deserialize<List<PokeModel>>(File.ReadAllText("pokenameall.json"));


    var abs = db.Abilities.ToList();
    id = poke.Max(s => s.Id);

    foreach (var ppk in Pokemondata.POKEMON)
    {
        if (!poke.Any(s => s.PokeFormId == ppk.FormId && ppk.name == s.FullNameChs))
        {
            if (ppk.name.Contains("超极巨化"))
            {
                continue;
                var sda = ppk.name.Split("-");
                var fname = ppk.name;
                if (sda.Length > 1)
                {
                    fname = string.Join("-", sda[1..]);
                }
                Console.WriteLine(ppk.name);
                var ppp = new Pokemon
                {
                    Ability1 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[0]]),
                    Ability2 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[1]]),
                    AbilityH = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[2]]),
                    BaseHP = ppk.RacialValue.Value[0],
                    BaseAtk = ppk.RacialValue.Value[1],
                    BaseDef = ppk.RacialValue.Value[2],
                    BaseSpa = ppk.RacialValue.Value[3],
                    BaseSpd = ppk.RacialValue.Value[4],
                    BaseSpe = ppk.RacialValue.Value[5],
                    FullNameChs = ppk.name,
                    FormNameChs = fname,
                    NameChs = ppk.NameList[0],
                    NameEng = Pokemondata.EnglishName[(int)Pokemondata.PokemonnameID[ppk.NameList[0]]],
                    PokeFormId = ppk.FormId,
                    Id = ++id,

                };

                db.Pokemons.Add(ppp);
            }

            if (ppk.name.Contains("洗翠"))
            {
                continue;
                Console.WriteLine(ppk.name);

                var sda = ppk.name.Split("-");
                var fname = ppk.name;
                if (sda.Length > 1)
                {
                    fname = string.Join("-", sda[1..]);
                }
                var ppp = new Pokemon
                {
                    Ability1 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[0]]),
                    Ability2 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[1]]),
                    AbilityH = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[2]]),
                    BaseHP = ppk.RacialValue.Value[0],
                    BaseAtk = ppk.RacialValue.Value[1],
                    BaseDef = ppk.RacialValue.Value[2],
                    BaseSpa = ppk.RacialValue.Value[3],
                    BaseSpd = ppk.RacialValue.Value[4],
                    BaseSpe = ppk.RacialValue.Value[5],
                    FullNameChs = ppk.name,
                    FormNameChs = fname,
                    NameChs = ppk.NameList[0],
                    NameEng = Pokemondata.EnglishName[(int)Pokemondata.PokemonnameID[ppk.NameList[0]]],
                    PokeFormId = ppk.FormId,
                    Id = ++id,

                };

                db.Pokemons.Add(ppp);
            }

            if (ppk.name.Contains("霸主"))
            {
                Console.WriteLine(ppk.name);
                continue;
                var sda = ppk.name.Split("-");
                var fname = ppk.name;
                if (sda.Length > 1)
                {
                    fname = string.Join("-", sda[1..]);
                }
                var ppp = new Pokemon
                {
                    Ability1 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[0]]),
                    Ability2 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[1]]),
                    AbilityH = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[2]]),
                    BaseHP = ppk.RacialValue.Value[0],
                    BaseAtk = ppk.RacialValue.Value[1],
                    BaseDef = ppk.RacialValue.Value[2],
                    BaseSpa = ppk.RacialValue.Value[3],
                    BaseSpd = ppk.RacialValue.Value[4],
                    BaseSpe = ppk.RacialValue.Value[5],
                    FullNameChs = ppk.name,
                    FormNameChs = fname,
                    NameChs = ppk.NameList[0],
                    NameEng = Pokemondata.EnglishName[(int)Pokemondata.PokemonnameID[ppk.NameList[0]]],
                    PokeFormId = ppk.FormId,
                    Id = ++id,

                };

                db.Pokemons.Add(ppp);
            }
            if (ppk.name.Contains("帕底亚"))
            {
                continue;
                Console.WriteLine(ppk.name);
                var sda = ppk.name.Split("-");
                var fname = ppk.name;
                if (sda.Length > 1)
                {
                    fname = string.Join("-", sda[1..]);
                }
                var ppp = new Pokemon
                {
                    Ability1 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[0]]),
                    Ability2 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[1]]),
                    AbilityH = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[2]]),
                    BaseHP = ppk.RacialValue.Value[0],
                    BaseAtk = ppk.RacialValue.Value[1],
                    BaseDef = ppk.RacialValue.Value[2],
                    BaseSpa = ppk.RacialValue.Value[3],
                    BaseSpd = ppk.RacialValue.Value[4],
                    BaseSpe = ppk.RacialValue.Value[5],
                    FullNameChs = ppk.name,
                    FormNameChs = fname,
                    NameChs = ppk.NameList[0],
                    NameEng = Pokemondata.EnglishName[(int)Pokemondata.PokemonnameID[ppk.NameList[0]]],
                    PokeFormId = ppk.FormId,
                    Id = ++id,

                };

                db.Pokemons.Add(ppp);
            }

            if (ppk.name.Contains("起源形态"))
            {
                Console.WriteLine(ppk.name);
                continue;
                var sda = ppk.name.Split("-");
                var fname = ppk.name;
                if (sda.Length > 1)
                {
                    fname = string.Join("-", sda[1..]);
                }
                var ppp = new Pokemon
                {
                    Ability1 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[0]]),
                    Ability2 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[1]]),
                    AbilityH = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[2]]),
                    BaseHP = ppk.RacialValue.Value[0],
                    BaseAtk = ppk.RacialValue.Value[1],
                    BaseDef = ppk.RacialValue.Value[2],
                    BaseSpa = ppk.RacialValue.Value[3],
                    BaseSpd = ppk.RacialValue.Value[4],
                    BaseSpe = ppk.RacialValue.Value[5],
                    FullNameChs = ppk.name,
                    FormNameChs = fname,
                    NameChs = ppk.NameList[0],
                    NameEng = Pokemondata.EnglishName[(int)Pokemondata.PokemonnameID[ppk.NameList[0]]],
                    PokeFormId = ppk.FormId,
                    Id = ++id,

                };

                db.Pokemons.Add(ppp);
            }

            if (ppk.name.Contains("白条纹"))
            {
                Console.WriteLine(ppk.name);
                continue;
                var sda = ppk.name.Split("-");
                var fname = ppk.name;
                if (sda.Length > 1)
                {
                    fname = string.Join("-", sda[1..]);
                }
                var ppp = new Pokemon
                {
                    Ability1 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[0]]),
                    Ability2 = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[1]]),
                    AbilityH = abs.First(s => s.Name_Eng == Pokemondata.AbilityEngName[ppk.AbilityList[2]]),
                    BaseHP = ppk.RacialValue.Value[0],
                    BaseAtk = ppk.RacialValue.Value[1],
                    BaseDef = ppk.RacialValue.Value[2],
                    BaseSpa = ppk.RacialValue.Value[3],
                    BaseSpd = ppk.RacialValue.Value[4],
                    BaseSpe = ppk.RacialValue.Value[5],
                    FullNameChs = ppk.name,
                    FormNameChs = fname,
                    NameChs = ppk.NameList[0],
                    NameEng = Pokemondata.EnglishName[(int)Pokemondata.PokemonnameID[ppk.NameList[0]]],
                    PokeFormId = ppk.FormId,
                    Id = ++id,

                };

                db.Pokemons.Add(ppp);
            }
            Console.WriteLine(ppk.name);
        }
    }
    db.SaveChanges();


    return;
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