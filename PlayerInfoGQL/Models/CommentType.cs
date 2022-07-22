namespace PlayerInfoGQL.Models
{
    public class CommentType
    {
        public int Id { get; set; }
        public CommentTypeEnum Description { get; set; } = default!;
    }
}