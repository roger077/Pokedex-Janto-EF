namespace ReactWithASP.Entities
{
    public class ListResponse
    {
        public int count { get; set; }
        public string next { get; set; }

        public string previous { get; set; }

        public Name_Url[] results { get; set; }
    }
}
