using PokeCommon.Models;
using PokemonDataAccess.Models;
using PokemonisshoniZ.Services;

namespace PokemonisshoniZ.Utils
{
    public class Utils
    {
        public static Item[] Items {  get; set; }
        public static Ability[] Abilities { get; set; }
        public static Move[] Moves { get; set; }
        public static Pokemon[] Pokemons { get; set; }
        public static PokeType[] PokeTypes { get; set; }
        public static Nature[] Natures { get; set; }
        public static Dictionary<string, Item> Name2Items { get; set; } = [];
        public static Dictionary<string, Ability> Name2Abilitiy { get; set; } = [];
        public static Dictionary<string, Move> Name2Move { get; set; } = [];
        public static Dictionary<string, Pokemon> Name2Poke { get; set; } = [];

        public static Dictionary<int, PSPokemon> PokeToPSPokemon = [];

        public static async Task Init(PokeCommonService pokeCommonService)
        {
            Abilities = await pokeCommonService.GetAbilities();
            Items = await pokeCommonService.GetItems();
            Moves = await pokeCommonService.GetMoves();
            Pokemons = await pokeCommonService.GetPokemons();
            PokeTypes = await pokeCommonService.GetPokeTypes();
            Natures = await pokeCommonService.GetNatures();


            Name2Items = Items
                .DistinctBy(s => s.Name_Chs)
                .ToDictionary(s => s.Name_Chs, s => s);
            Name2Abilitiy = Abilities
                .DistinctBy(s => s.Name_Chs)
                .ToDictionary(s => s.Name_Chs, s => s);
            Name2Move = Moves
                .DistinctBy(s => s.Name_Chs)
                .ToDictionary(s => s.Name_Chs, s => s);
            Name2Poke = Pokemons
                .DistinctBy(s => s.FullNameChs)
                .ToDictionary(s => s.FullNameChs, s => s);

            var pspoke = await pokeCommonService.GetPSPokemons();
            PokeToPSPokemon = pspoke.DistinctBy(s => s.PokemonId).ToDictionary(s => s.PokemonId.Value, s => s);

        }


        public static TextPokemon GetTextPokemon(GamePokemon pokemon)
        {
            TextPokemon textPokemon = new TextPokemon();
            if (pokemon?.MetaPokemon == null) return textPokemon;
            textPokemon.Name = pokemon.MetaPokemon.FullNameChs;
            textPokemon.Ability = pokemon.Ability?.Name_Chs;
            textPokemon.Item = pokemon.Item?.Name_Chs;
            // 4长度必备
            textPokemon.Move = pokemon.Moves.Select(s => s?.NameChs).ToArray();

            textPokemon.EVs = pokemon.EVs.ToSixArray();
            textPokemon.IVs = pokemon.IVs.ToSixArray();

            // 要能直接修改能力值

            return textPokemon;
        }

        public static void ModifyGamePokemon(GamePokemon source,  TextPokemon pokemon)
        {
            try
            {
                source.MetaPokemon = Name2Poke[pokemon.Name];
                source.Item = Name2Items[pokemon.Item];
                source.Ability = Name2Abilitiy[pokemon.Ability];
                for (int i = 0; i < source.Moves.Count; i++)
                {
                    source.Moves[i].MetaMove = Name2Move[pokemon.Move[i]];
                }


            }
            catch (Exception ex)
            {
                // Todo
            }
            // 要怎么使用工具集
        }
    }
}
