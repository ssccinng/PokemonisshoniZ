namespace PokemonisshoniZ.Data
{
    public class PokeTeam
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public string PSText { get; set; } = string.Empty;

        public int[] PokemonIds { get; set; } = new int[6];

        public bool Islock { get; set; } = false; //锁住用户修改权限 
        public string Remark { get; set; } = string.Empty;
        /// <summary>
        /// json化
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();
    }
}
