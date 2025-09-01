using Microsoft.EntityFrameworkCore;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Infrastructure.Data;

namespace RestaurantGraphQL.Infrastructure.Repositories;

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

    public async Task<bool> Update(Menu menu)
    {
        var existingMenu = await _context.Menus.FindAsync(menu.Id);
        if (existingMenu == null)
            return false;

        _context.Entry(existingMenu).CurrentValues.SetValues(menu);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var menu = await _context.Menus.FindAsync(id);
        if (menu == null)
        {
            return false;
        }

        _context.Menus.Remove(menu);

        await _context.SaveChangesAsync();

        return true;
    }
}