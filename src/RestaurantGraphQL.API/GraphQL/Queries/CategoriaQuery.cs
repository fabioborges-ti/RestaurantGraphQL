using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class CategoriaQuery
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Categoria> GetCategorias([Service] ICategoriaRepository repository)
        {
            return repository.GetAll();
        }

        public async Task<Categoria?> GetCategoriaById(int id, [Service] ICategoriaRepository repository)
        {
            return await repository.GetById(id);
        }
    }
}