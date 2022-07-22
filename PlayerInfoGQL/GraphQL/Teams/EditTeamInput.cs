namespace PlayerInfoGQL.GraphQL.Teams
{
    [GraphQLDescription("Edits team name, country and league by team ID")]
    public record EditTeamInput(int Id, string Name, string Country, string League);
}