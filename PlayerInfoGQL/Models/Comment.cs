namespace PlayerInfoGQL.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public Player Player { get; set; }
    }
}