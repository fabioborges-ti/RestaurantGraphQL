using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Infrastructure.Data;

namespace RestaurantGraphQL.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva?> GetById(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public IQueryable<Reserva> GetAll()
        {
            return _context.Reservas.AsQueryable();
        }

        public async Task Add(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Reserva reserva)
        {
            var existingReserva = await _context.Reservas.FindAsync(reserva.Id);
            if (existingReserva != null)
            {
                // Copia os valores das propriedades, exceto a chave primária
                _context.Entry(existingReserva).CurrentValues.SetValues(reserva);
                await _context.SaveChangesAsync();
            }
            // Opcional: Lançar uma exceção se a reserva não for encontrada
            // else
            // {
            //     throw new Exception("Reserva não encontrada.");
            // }
        }

        public async Task Delete(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }
    }
}