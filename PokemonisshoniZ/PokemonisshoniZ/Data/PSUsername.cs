using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonisshoniZ.Data
{
    public class PSUsername
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }

  

        [Column(TypeName = "varchar(50)")]
        public string PSName { get; set; } = string.Empty;
    }
}
