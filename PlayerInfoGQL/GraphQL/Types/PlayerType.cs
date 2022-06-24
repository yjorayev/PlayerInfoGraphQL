using PlayerInfoGQL.Data;
using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.GraphQL.Types
{
    public class PlayerType : ObjectType<Player>
    {
        protected override void Configure(IObjectTypeDescriptor<Player> descriptor)
        {
            descriptor.Description("Represents a football player.");

            descriptor.Field(p => p.FirstName).Description("Player's first name.");
            descriptor.Field(p => p.LastName).Description("Player's last name.");
            descriptor.Field(p => p.Country).Description("A Country which this player represents.");
            descriptor.Field(p => p.Age).Description("Player's age.");
            descriptor.Field(p => p.Position).Description("Player's natural position on the field.");
            descriptor.Field(p => p.PotentialScore).Description("Player's potential skill level in a scale of 100.");
            descriptor.Field(p => p.BehaviourScore).Description("Player's behaviour score in a scale of 10.");
            descriptor.Field(p => p.LoyaltyScore).Description("Player's loyalty score in a scale of 10.");
            descriptor.Field(p => p.TeamId).Description("TeamId of a team which this player represents.");
            descriptor.Field(p => p.AnalysisResult).Description("Analysis result for this player.");

            descriptor
                .Field(p => p.Comments)
                .ResolveWith<Resolvers>(p => p.GetComments(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("List of comments addressed to this player.")
                .UseFiltering();

            descriptor
                .Field(p => p.Team)
                .ResolveWith<Resolvers>(p => p.GetTeam(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("A team which this player represents.")
                .UseFiltering();

        }

        private class Resolvers
        {
            public IQueryable<Comment> GetComments([Parent] Player player, [ScopedService] AppDbContext context)
            {
                return context.Comments.Where(c => c.PlayerId == player.Id);
            }

            public Team GetTeam([Parent] Player player, [ScopedService] AppDbContext context)
            {
                return context.Teams.Single(t => t.Id == player.TeamId);
            }
        }

    }
}