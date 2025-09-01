using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Core.Interfaces.Repositories;

public interface IMenuRepository
{
    IQueryable<Menu> GetAll();
    Task<Menu?> GetById(int id);
    Task Add(Menu menu);
    Task<bool> Update(Menu menu);
    Task<bool> Delete(int id);
}
