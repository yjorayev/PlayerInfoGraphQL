using PlayerInfoGQL.Data;
using Microsoft.EntityFrameworkCore;
using PlayerInfoGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using PlayerInfoGQL.GraphQL.Types;
using PlayerInfoGQL.GraphQL.Teams;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PlayerInfo");

builder.Services
    .AddPooledDbContextFactory<AppDbContext>(x => x
        .UseSqlite(connectionString)
        .EnableDetailedErrors());

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<TeamType>()
    .AddType<PlayerType>()
    .AddType<CommentTypeType>()
    .AddType<CommentType>()
    .AddType<AnalysisResultType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.UseGraphQLVoyager(new VoyagerOptions()
    {
        GraphQLEndPoint = "/graphql",
    }, "/graphql-voyager");

app.Run();
