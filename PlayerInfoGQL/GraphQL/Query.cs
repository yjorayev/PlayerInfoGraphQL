using PlayerInfoGQL.Data;
using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Team> GetTeam([ScopedService] AppDbContext context)
        {
            return context.Teams;
        }

    }
}