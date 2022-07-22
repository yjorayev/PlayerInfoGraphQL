namespace PlayerInfoGQL.GraphQL.Comments
{
    public record AddCommentInput
    {
        public int PlayerId { get; set; }

        public CommentTypeEnum CommentType { get; init; }

        public string Text { get; init; } = default!;
    }
}