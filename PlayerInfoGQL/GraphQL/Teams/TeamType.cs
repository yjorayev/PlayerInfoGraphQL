using PlayerInfoGQL.Data;
using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.GraphQL.Teams
{
    public class TeamType : ObjectType<Team>
    {
        protected override void Configure(IObjectTypeDescriptor<Team> descriptor)
        {
            descriptor.Description("Represents a football team.");

            //descriptor.Field(t => t.Id).Ignore();

            descriptor.Field(t => t.Name).Description("Team name.");
            descriptor.Field(t => t.Country).Description("Team's origin country.");
            descriptor.Field(t => t.League).Description("League name at which this team is currently competing.");
            descriptor
                .Field(t => t.Players)
                .Description("List of players of this team.")
                .ResolveWith<Resolvers>(t => t.GetPlayers(default!, default!))
                .UseDbContext<AppDbContext>()
                .UseFiltering();
        }

        private class Resolvers
        {
            public IQueryable<Player> GetPlayers([Parent] Team team, [ScopedService] AppDbContext context)
            {
                return context.Players.Where(p => p.TeamId == team.Id);
            }
        }
    }
}