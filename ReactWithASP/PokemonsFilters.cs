using DB;

namespace ReactWithASP
{
    public class PokemonsFilters
    {
        /*"{Name}/{HP}/{Attack}/{Defense}/{Speed}/{Height}/{Weight}/{Types}"*/
        public string? Name { get; set; }
        public MinMax? HP { get; set; }
        public MinMax? Attack { get; set; }
        public MinMax? Defense { get; set; }
        public MinMax? Speed { get; set; }
        public MinMax? Height { get; set; }
        public MinMax? Weight { get; set; }
        public int[]? Types { get; set; }


        /*public IQueryable<Pokemon> ApplyFilters(IQueryable<Pokemon> query)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(p => p.Name == Name);
            }

            if (HP != null)
            {
                query = query.Where(p => p.HP >= HP.Min && p.HP <= HP.Max);
            }

            if (Attack != null)
            {
                query = query.Where(p => p.Attack >= Attack.Min && p.Attack <= Attack.Max);
            }

            // Aplicar otros filtros según sea necesario...

            return query;
        }*/
    }
}
