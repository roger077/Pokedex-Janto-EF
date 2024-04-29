using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Entities;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Http.Json;
using System;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ReactWithASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        //readonly 
        PokemonDbContext _context;

        public PokemonController(PokemonDbContext context)
        {
            _context = context;
        }


        async Task<T> RequestAPI<T>(string url)
        {
            try
            {
                T response;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage res = await client.GetAsync(url);
                    if (!res.IsSuccessStatusCode)
                        throw new Exception("Error when making the request to the API");
                    string content = await res.Content.ReadAsStringAsync();
                    response = JsonSerializer.Deserialize<T>(content);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                    

        [HttpGet]     
        public async Task<ActionResult<List<Pokemon>>> GetPokemons([FromQuery] PokemonsFilters filters)
        {
            try
            {  
                IQueryable<Pokemon> query = _context.Pokemons;
                
                
                if (!string.IsNullOrEmpty(filters.Name))
                {
                    query = query.Where(p => p.Name.ToUpper().Contains(filters.Name.ToUpper()));
                }

                if (filters.HP != null)
                {
                    query = query.Where(p => p.HP >= filters.HP.Min && p.HP <= filters.HP.Max);
                }

                if (filters.Attack != null)
                {
                    query = query.Where(p => p.Attack >= filters.Attack.Min && p.Attack <= filters.Attack.Max);
                }

                if (filters.Defense != null)
                {
                    query = query.Where(p => p.Defense >= filters.Defense.Min && p.Defense <= filters.Defense.Max);
                }

                if (filters.Speed != null)
                {
                    query = query.Where(p => p.Speed >= filters.Speed.Min && p.Speed <= filters.Speed.Max);
                }

                if (filters.Height != null)
                {
                    query = query.Where(p => p.Height >= filters.Height.Min && p.Height <= filters.Height.Max);
                }

                if (filters.Weight != null)
                {
                    query = query.Where(p => p.Weight >= filters.Weight.Min && p.Weight <= filters.Weight.Max);
                }

                if (filters.Types != null && filters.Types.Any())
                {
                    query = query.Where(p => p.Types.Any(t => filters.Types.Contains(t.TypeId)));
                }

                var pokemons = await query.Select(p => new
                {
                    PokemonId = p.PokemonId,
                    Num = p.Num,
                    Name = p.Name,
                    Defense = p.Defense,
                    Attack = p.Attack,
                    HP = p.HP,
                    Speed = p.Speed,
                    Weight = p.Weight,
                    Height = p.Height,
                    Types = p.Types.Select(t => new
                    {
                        TypeId = t.TypeId,
                        Name = t.Name
                    }).ToList()
                })
                .ToListAsync();

                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("/types")]

        public async Task<ActionResult<List<TypePokemon>>> GetTypes()
        {
            try
            {
                IQueryable<TypePokemon> query = _context.Types;

                var types = await query.Select(t => new
                {
                    TypeId = t.TypeId,
                    Name = t.Name

                }).ToListAsync();

                return Ok(types);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetDetailsPokemonById(int id)
        {
            try
            {
                // Eager Loading => Incluir las relaciones que querramos en una unica consulta
                var pokemon = await _context.Pokemons.Select(p => new
                {
                    PokemonId = p.PokemonId,
                    Num = p.Num,
                    Name = p.Name,
                    Defense = p.Defense,
                    Attack = p.Attack,
                    HP = p.HP,
                    Speed = p.Speed,
                    Weight = p.Weight,
                    Height = p.Height,
                    Types = p.Types.Select(t => new
                    {
                        TypeId = t.TypeId,
                        TypeName = t.Name
                    }).ToList()
                }).FirstOrDefaultAsync(p=>p.PokemonId == id);

                if (pokemon == null)
                    return NotFound();
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       
        [HttpPost("LoadFromAPI")]
        public async Task<ActionResult<string>> LoadFromAPI()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ListResponse typesResult = await RequestAPI<ListResponse>("https://pokeapi.co/api/v2/type");
                    ListResponse pokemonResult = await RequestAPI <ListResponse> ("https://pokeapi.co/api/v2/pokemon?limit=151");

                    if (_context.Types.Count() == 0)
                    {
                        foreach(Name_Url t in typesResult.results)
                        {
                            TypePokemon newType = new TypePokemon()
                            {
                                Name = t.name
                            };
                            _context.Types.Add(newType);
                            _context.SaveChanges();
                        }
                    }

                    if (_context.Pokemons.Count() == 0)
                    {
                        foreach (Name_Url p in pokemonResult.results)
                        {
                            HttpResponseMessage resPkmnDetails = await client.GetAsync(p.url);
                            if (resPkmnDetails.IsSuccessStatusCode)
                            {
                                string result = await resPkmnDetails.Content.ReadAsStringAsync();
                                PokemonRequestDetail pokeDetailsResult = await RequestAPI<PokemonRequestDetail>(result);
                                Pokemon newPokemon = new Pokemon()
                                {
                                    Num = pokeDetailsResult.id,
                                    Name = pokeDetailsResult.name,
                                    HP = pokeDetailsResult.stats[0].base_stat,
                                    Attack = pokeDetailsResult.stats[1].base_stat,
                                    Defense = pokeDetailsResult.stats[2].base_stat,
                                    Speed = pokeDetailsResult.stats[5].base_stat,
                                    Height = pokeDetailsResult.height,
                                    Weight = pokeDetailsResult.weight,                              
                                };
                                foreach (TypeR t in pokeDetailsResult.types)
                                {
                                    string name = t.type.name;
                                    TypePokemon currentType = _context.Types.Single(tp => tp.Name == name);
                                    newPokemon.Types.Add(currentType);
                                }
                            
                                _context.Pokemons.Add(newPokemon);
                                _context.SaveChanges();

                            }
                        }
                    }
                }
                return Ok("The Database was loaded successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
