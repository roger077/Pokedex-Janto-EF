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
    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PokemonId
        {
            get; set;
        }
        [Required]
        public string Name
        {
            get; set;
        }
        [Required]
        public int Num
        {
            get; set;
        }
        [Required]
        public double HP
        {
            get; set;
        }
        [Required]
        public double Defense
        {
            get; set;
        }
        [Required]
        public double Speed
        {
            get; set;
        }
        [Required]
        public double Height
        {
            get; set;
        }
        //double hp, defense,speed, height, attack, weight;
        [Required]
        public double Attack
        {
            get; set;
        }
        [Required]
        public double Weight
        {
            get; set;
        }
        //[JsonIgnore]
        public ICollection<TypePokemon> Types { get; } = [];
       //public ICollection<PokemonType> PokemonTypes { get; } = [];

    }
}
