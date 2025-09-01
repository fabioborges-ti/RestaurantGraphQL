using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ReservaQuery
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Reserva> GetReservas([Service] IReservaRepository repository)
        {
            return repository.GetAll();
        }

        public async Task<Reserva?> GetReservaById(int id, [Service] IReservaRepository repository)
        {
            return await repository.GetById(id);
        }
    }
}
