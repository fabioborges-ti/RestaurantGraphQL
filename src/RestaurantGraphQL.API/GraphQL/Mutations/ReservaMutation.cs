using RestaurantGraphQL.API.GraphQL.Inputs;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Mutations
{
    public class ReservaMutation
    {
        public async Task<Reserva> AddReserva(ReservaInput input, [Service] IReservaRepository repository)
        {
            var reserva = new Reserva
            {
                DataHora = input.DataHora,
                NomeCliente = input.NomeCliente,
                NumeroPessoas = input.NumeroPessoas,
                Observacoes = input.Observacoes
            };

            await repository.Add(reserva);

            return reserva;
        }
    }
}