namespace PlayerInfoGQL.GraphQL.Teams
{
    [GraphQLDescription("Adds a team into database")]
    public record AddTeamInput
    {
        [GraphQLDescription("team's name")]
        public string Name { get; init; } = default!;

        [GraphQLDescription("team's country")]
        public string Country { get; init; } = default!;

        [GraphQLDescription("team's league")]
        public string League { get; init; } = default!;
    }

}