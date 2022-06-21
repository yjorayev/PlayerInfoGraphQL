namespace PlayerInfoGQL.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public string Type { get; set; } = default!;

        public string Text { get; set; } = default!;

        public Player Player { get; set; } = default!;
    }
}