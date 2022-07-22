using PlayerInfoGQL.Data;
using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.GraphQL.Comments
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Description("Represents a comment for a footballer.");

            descriptor.Field(c => c.PlayerId).Description("PlayerId to which a comment is addressed.");
            descriptor.Field(c => c.Type).Description("A comment type.");
            descriptor.Field(c => c.Text).Description("Text of a comment.");

            descriptor
                .Field(c => c.Player)
                .Description("Player to which a comment is addressed.")
                .ResolveWith<Resolvers>(r => r.GetPlayer(default!, default!))
                .UseDbContext<AppDbContext>()
                .UseFiltering();
        }

        private class Resolvers
        {
            public Player GetPlayer([Parent] Comment comment, [ScopedService] AppDbContext context)
            {
                return context.Players.Single(p => p.Id == comment.PlayerId);
            }
        }
    }
}