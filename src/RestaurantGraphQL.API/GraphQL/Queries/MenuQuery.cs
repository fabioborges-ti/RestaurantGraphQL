using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class MenuQuery
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Menu> GetMenus([Service] IMenuRepository repository)
        {
            return repository.GetAll();
        }

        public async Task<Menu?> GetMenuById(int id, [Service] IMenuRepository repository)
        {
            return await repository.GetById(id);
        }
    }
}
