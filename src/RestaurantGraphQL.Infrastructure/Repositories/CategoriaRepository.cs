using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Infrastructure.Data;

namespace RestaurantGraphQL.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Categoria> GetAll()
        {
            return _context.Categorias.AsQueryable();
        }

        public async Task<Categoria?> GetById(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task Add(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Categoria categoria)
        {
            var existingCategoria = await _context.Categorias.FindAsync(categoria.Id);

            if (existingCategoria == null)
                return false;

            _context.Entry(existingCategoria).CurrentValues.SetValues(categoria);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return false;
            }

            _context.Categorias.Remove(categoria);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}