namespace PlayerInfoGQL.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }

        public int? PotentialScore { get; set; }

        public int? BehaviourScore { get; set; }

        public int? LoyaltyScore { get; set; }

        public int TeamId { get; set; }

        public string AnalysisResult { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = Enumerable.Empty<Comment>();

        public Team Team { get; set; }
    }
}