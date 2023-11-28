
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemonisshoni
{
    class PokemonBase
    {

        public string name { get; set; }
        public int PokemonID;
        public string[] NameList { get; set; }
        public int[] TypeId { get; set; }
        public int[] AbilityList { get; set; }
        public string[] movelist; // 未完�?
        public int FormId { get; set; }
        public Racial RacialValue { get; set; }

        public PokemonBase(string name, int PokemonID, string[] NameList, int[] TypeId, int[] AbilityList, int FormId,
                Racial racial)
        {
            this.name = name;
            this.PokemonID = PokemonID;
            this.NameList = NameList;
            this.TypeId = TypeId;
            this.AbilityList = AbilityList;
            this.FormId = FormId;
            this.RacialValue = racial;
        }

        public PokemonBase()
        {
            RacialValue = new Racial();
        }
        


    }

}
