using Microsoft.EntityFrameworkCore;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Infrastructure.Repositories;

namespace RestaurantGraphQL.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<GraphQLDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            return services;
        }
    }
}