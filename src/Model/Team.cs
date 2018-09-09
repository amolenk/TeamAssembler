namespace Model
{
    public class Team
    {
        public string Name { get; set; }

        public string[] Members { get; set; }

        public int Score { get; set; }

        public PowerGrid PowerGrid { get; set; }
    }
}