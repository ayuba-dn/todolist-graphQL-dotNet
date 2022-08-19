using TodoListQL.data;
using Microsoft.EntityFrameworkCore;
using TodoListQL.GraphQl;
using GraphQL.Server.Ui.Voyager;
using TodoListQL.GraphQL.Lists;

var builder = WebApplication.CreateBuilder(args);
var DefaulConnection = builder.Configuration.GetValue<string>("ConnectionStrings:DefaulConnection");


builder.Services.AddPooledDbContextFactory<ApiDbContext>(options=> options.UseSqlite(
    DefaulConnection
));


builder.Services.AddGraphQLServer()
.AddQueryType<Query>()
.AddType<TodoListQL.GraphQL.DataItem.ListType>()
.AddMutationType<Mutation>()
.AddProjections()
.AddFiltering()
.AddSorting();

var app = builder.Build();




// app.MapGet("/", () => "Hello World! >>>"+DefaulConnection);

app.UseRouting();
app.UseEndpoints(endpoints =>{
    endpoints.MapGraphQL();
});

// app.UseGraphQLVoyager("/graphql-voyager");

app.UseGraphQLVoyager("/graphql-voyager",new VoyagerOptions { GraphQLEndPoint = "/graphql" });

app.Run();
