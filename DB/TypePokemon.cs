using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DB
{
    public class TypePokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId
        {
            get; set;
        }
        [Required]
        public string Name
        {
            get; set;
        }
        //[JsonIgnore]
        public  ICollection<Pokemon> Pokemons { get; } = [];

        //public ICollection<PokemonType> PokemonTypes { get; } = [];

    }
}
