namespace PokemonisshoniZ.Data
{
    public class PokeTeam
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public string PSText { get; set; } = string.Empty;

        public List<int> PokemonIds { get; set; } = new();

        public bool Islock { get; set; } = false; //锁住用户修改权限 
        /// <summary>
        /// json化
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();
    }
}
