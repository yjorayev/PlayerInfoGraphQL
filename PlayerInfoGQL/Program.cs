using PlayerInfoGQL.Data;
using Microsoft.EntityFrameworkCore;
using PlayerInfoGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using PlayerInfoGQL.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PlayerInfo");

builder.Services
    .AddPooledDbContextFactory<AppDbContext>(x => x
        .UseSqlite(connectionString)
        .EnableDetailedErrors());

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<TeamType>()
    .AddType<PlayerType>()
    .AddType<CommentTypeType>()
    .AddType<CommentType>()
    .AddType<AnalysisResultType>()
    .AddFiltering()
    .AddSorting();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections();

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
