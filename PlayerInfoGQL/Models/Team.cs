namespace PlayerInfoGQL.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Country { get; set; } = default!;

        public string League { get; set; } = default!;

        public IEnumerable<Player> Players { get; set; } = Enumerable.Empty<Player>();
    }
}