using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonisshoniZ.Data
{
    /// <summary>
    /// 宝可梦盒子
    /// </summary>
    public class PCLPokemonBox
    {

        public long Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId {  get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public int BoxIdx { get; set; }

        public List<int> PCLPokemonIds { get; set; } = new();

    }
}
