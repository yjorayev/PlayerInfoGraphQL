using PlayerInfoGQL.Data;
using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Team> GetTeam([ScopedService] AppDbContext context)
        {
            return context.Teams;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Player> GetPlayer([ScopedService] AppDbContext context)
        {
            return context.Players;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AnalysisResult> GetAnalysisResult([ScopedService] AppDbContext context)
        {
            return context.AnalysisResults;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Comment> GetComments([ScopedService] AppDbContext context)
        {
            return context.Comments;
        }
    }
}