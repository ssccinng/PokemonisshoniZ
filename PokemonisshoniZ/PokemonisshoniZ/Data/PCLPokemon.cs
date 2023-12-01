using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonisshoniZ.Data
{
    public class PCLPokemon
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public long Id { get; set; }
        /// <summary>
        /// 宝可梦id
        /// </summary>
        public long PokeId { get; set; }
        /// <summary>
        /// 宝可梦tag
        /// </summary>
        public List<string> Tags { get; set; } = new();


        [Column(TypeName = "nvarchar(1000)")]
        public string PSText { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;
    }
}
