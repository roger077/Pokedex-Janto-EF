namespace ReactWithASP.Entities
{
    public class PokemonRequestDetail
    {
        public IList<Abilities> abilities { get; set; }
        public int baseExperience { get; set; }
        public IList</*Form*/Name_Url> forms { get; set; }
        public IList<GameIndice> gameIndices { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public IList<object> heldItems { get; set; }
        public int id { get; set; }
        public bool isDefault { get; set; }
        public string locationAreaEncounters { get; set; }
        public IList</*Move*/Name_Url> moves { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public Name_Url species { get; set; }
        public IList<Stat> stats { get; set; }
        public IList<TypeR> types { get; set; }
    }
}
