using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Core.Interfaces.Repositories;

public interface IReservaRepository
{
    IQueryable<Reserva> GetAll();
    Task<Reserva?> GetById(int id);
    Task Add(Reserva reserva);
    Task<Reserva?> Update(int id, Reserva reserva);
    Task<bool> Delete(int id);
}
