using Microsoft.EntityFrameworkCore;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Infrastructure.Data;

namespace RestaurantGraphQL.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Menu> GetAll()
        {
            return _context.Menus;
        }

        public async Task<Menu?> GetById(int id)
        {
            return await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }
    }
}