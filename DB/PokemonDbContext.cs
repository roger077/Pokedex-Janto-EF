using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class PokemonDbContext:DbContext
    {
        //La instancia de DbContextOptions contiene información de configuración, como la cadena de conexión, el proveedor de la base de datos que se utiliza, etc
        //Pasamos DbContextOptions al constructor de la clase base DbContext usando la palabra clave base como se muestra a continuación.
        public PokemonDbContext()
        {
            
        }
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<TypePokemon> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasMany(p => p.Types)
                .WithMany(t => t.Pokemons)
                .UsingEntity<PokemonType>(
                    //l => l.HasOne<TypePokemon>(pt=>pt.Type).WithMany(e => e.PokemonTypes),
                    //r => r.HasOne<Pokemon>(pt=>pt.Pokemon).WithMany(e => e.PokemonTypes)
                );
        }

    }
}
