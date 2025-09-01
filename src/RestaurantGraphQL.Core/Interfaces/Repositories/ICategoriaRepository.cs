using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Core.Interfaces.Repositories;

public interface ICategoriaRepository
{
    IQueryable<Categoria> GetAll();
    Task<Categoria?> GetById(int id);
    Task Add(Categoria categoria);
}
