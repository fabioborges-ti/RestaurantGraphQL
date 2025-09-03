using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly GraphQLDbContext _context;

        public ReservaRepository(GraphQLDbContext context)
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

        public async Task<Reserva?> Update(int id, Reserva reserva)
        {
            var existingReserva = await _context.Reservas.FindAsync(id);

            if (existingReserva == null)
                return null;

            existingReserva.DataHora = reserva.DataHora;
            existingReserva.NomeCliente = reserva.NomeCliente;
            existingReserva.NumeroPessoas = reserva.NumeroPessoas;
            existingReserva.Observacoes = reserva.Observacoes;

            await _context.SaveChangesAsync();

            return existingReserva;
        }

        public async Task<bool> Delete(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
                return false;

            _context.Reservas.Remove(reserva);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
