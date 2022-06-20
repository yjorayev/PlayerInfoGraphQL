namespace PlayerInfoGQL.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string League { get; set; }

        public IEnumerable<Player> Players { get; set; } = Enumerable.Empty<Player>();
    }
}