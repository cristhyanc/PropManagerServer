
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropManagerServer.Queries;
using PropManagerServer.Mutations;
using PropManagerServer.Mutations.PropertyMutations;
using PropManagerServer.Mutations.LoanMutations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PropManagerModel.PropManagerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddGraphQLServer()
    .AddMutationConventions(applyToAllMutations: true)
    .AddQueryType(x=> x.Name("Query"))
    .AddMutationType(x=> x.Name("Mutation"))
    .AddType<PropertyQueries>()
    .AddType<LoanQueries>()
    .AddType<AddPropertyM>()
    .AddType<EditPropertyM>()
    .AddType<DeletePropertyM>()
    .AddType<AddLoanM>()
    .AddType<EditLoanM>()
    .AddType<DeleteLoanM>()
    .AddFiltering();

builder.Services.AddCors(options =>
{
    options.AddPolicy("devPolicy", builderPolicy =>
    {
        builderPolicy.AllowAnyOrigin().AllowAnyHeader().
        AllowAnyMethod();
    });
});
var app = builder.Build();
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");
app.UseCors("devPolicy");
app.Run();

