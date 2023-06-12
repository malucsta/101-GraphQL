using GraphQL.Demo.API.Schema.Subscriptions;
using GraphQL.Demo.API.Schema.Mutations;
using GraphQL.Demo.API.Schema.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();
app.UseWebSockets();

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();



app.Run();
