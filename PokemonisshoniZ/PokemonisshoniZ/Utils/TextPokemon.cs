namespace PokemonisshoniZ.Utils
{
    public class TextPokemon
    {
        public string Name { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public string Ability { get; set; } = string.Empty;
        public string[] Move { get; set; } = new string[4] { string.Empty, string.Empty, string.Empty, string.Empty };
        public int[] EVs { get; set; } = new int[6];
        public int[] IVs { get; set; } = new int[6];
    }
}
