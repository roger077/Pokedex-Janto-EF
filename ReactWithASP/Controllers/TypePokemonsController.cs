using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB;

namespace ReactWithASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePokemonsController : ControllerBase
    {
        private readonly PokemonDbContext _context;

        public TypePokemonsController(PokemonDbContext context)
        {
            _context = context;
        }

        // GET: api/TypePokemons
        [HttpGet]
        public async Task<ActionResult<List<TypePokemon>>> GetTypePokemon()
        {
            try
            {
                var types = await _context.Types.Select(t => new
                {
                    TypeId = t.TypeId,
                    TypeName = t.Name,
                    Pokemons = t.Pokemons.Select(p => new
                    {
                        PokemonId = p.PokemonId,
                        Num = p.Num, 
                        Name = p.Name,                        
                        /*
                        Defense = p.Defense,
                        Attack = p.Attack,
                        HP = p.HP,
                        Speed = p.Speed,
                        Weight = p.Weight,
                        Height = p.Height,
                        */
                    }).ToList()
                }).ToListAsync();


                return Ok(types);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
