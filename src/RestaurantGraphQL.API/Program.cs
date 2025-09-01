using Microsoft.EntityFrameworkCore;
using RestaurantGraphQL.API.Extensions;
using RestaurantGraphQL.API.GraphQL.Mutations;
using RestaurantGraphQL.API.GraphQL.Queries;
using RestaurantGraphQL.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a configura��o do banco de dados
builder.Services.AddDatabase(builder.Configuration);

// Adiciona os reposit�rios
builder.Services.AddRepositories();

// Adiciona os servi�os do HotChocolate GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType()
        .AddTypeExtension<CategoriaQuery>()
        .AddTypeExtension<MenuQuery>()
        .AddTypeExtension<ReservaQuery>()
    .AddMutationType()
        .AddTypeExtension<MenuMutation>()
        .AddTypeExtension<ReservaMutation>()
        .AddTypeExtension<CategoriaMutation>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

// Aplica as migra��es pendentes do EF Core
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            await context.Database.MigrateAsync();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

app.MapGraphQL();

app.Run();
