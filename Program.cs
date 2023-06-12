using GraphQL.Demo.API.Schema.Subscriptions;
using GraphQL.Demo.API.Schema.Mutations;
using GraphQL.Demo.API.Schema.Queries;
using GraphQL.Demo.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

// AddPooledDbContextFactory ensures that we will have a pool of DbContext's ready
// This allows HotChocolate to safely execute EF operations in parallel
string connectionString = builder.Configuration.GetConnectionString("default")!;
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString));

var app = builder.Build();
app.UseWebSockets();

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();

using(var scope = app.Services.CreateScope())
{
    var factory = app.Services.GetRequiredService<IDbContextFactory<SchoolDbContext>>();
    using var context = factory.CreateDbContext();
    context.Database.Migrate();
}

app.Run();
