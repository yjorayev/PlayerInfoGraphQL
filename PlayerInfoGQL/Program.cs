using PlayerInfoGQL.Data;
using Microsoft.EntityFrameworkCore;
using PlayerInfoGQL.GraphQL;
using Microsoft.AspNetCore.Builder;
using GraphQL.Server.Ui.Voyager;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PlayerInfo");

builder.Services
    .AddPooledDbContextFactory<AppDbContext>(x => x
        .UseSqlite(connectionString)
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging());

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
