using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonisshoniZ.Data
{
    public class PCLPokemon
    {
        public long Id { get; set; }
        /// <summary>
        /// 宝可梦id
        /// </summary>
        public long PokeId { get; set; }

        public List<string> Tags { get; set; } = new();


        [Column(TypeName = "nvarchar(1000)")]
        public string PSText { get; set; }
    }
}
