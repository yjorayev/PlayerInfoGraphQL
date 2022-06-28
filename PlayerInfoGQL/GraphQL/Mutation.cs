using PlayerInfoGQL.Data;
using PlayerInfoGQL.GraphQL.Teams;
using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddTeamPayload> AddTeamAsync(AddTeamInput input, [ScopedService] AppDbContext context)
        {
            var team = new Team
            {
                Name = input.Name,
                Country = input.Country,
                League = input.League
            };
            context.Teams.Add(team);
            await context.SaveChangesAsync();

            return new AddTeamPayload(team);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddTeamPayload> EditTeamAsync(EditTeamInput input, [ScopedService] AppDbContext context)
        {
            var team = context.Teams.Single(t => t.Id == input.Id);

            team.Name = input.Name;
            team.Country = input.Country;
            team.League = input.League;

            await context.SaveChangesAsync();
            return new AddTeamPayload(team);
        }
    }
}