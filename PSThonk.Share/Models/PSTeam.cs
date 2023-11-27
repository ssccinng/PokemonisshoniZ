using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSThonk.Share.Models
{
    public class PSTeam
    {
        public int Id { get; set; }

        public PSPokemon poke1 { get; set; }
        public PSPokemon poke2 { get; set; }
        public PSPokemon poke3 { get; set; }
        public PSPokemon poke4 { get; set; }
        public PSPokemon poke5 { get; set; }
        public PSPokemon poke6 { get; set; }
        [NotMapped]
        public List<PSPokemon> pokemons => new List<PSPokemon> { poke1, poke2, poke3, poke4, poke5, poke6 };
        public List<int> pokemonids => new List<int> { poke1Id, poke2Id, poke3Id, poke4Id, poke5Id, poke6Id };
        public int poke1Id { get; set; }
        public int poke2Id { get; set; }
        public int poke3Id { get; set; }
        public int poke4Id { get; set; }
        public int poke5Id { get; set; }
        public int poke6Id { get; set; }
        public int Score { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public DateTime TeamTime { get; set; }

    }
}
