namespace PokemonisshoniZ.Data
{
    public class PokeTeam
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public string PSText { get; set; } = string.Empty;

        /// <summary>
        /// json化
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();
    }
}
