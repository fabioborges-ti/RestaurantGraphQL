using RestaurantGraphQL.API.GraphQL.Inputs;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class ReservaMutation
{
    public async Task<Reserva> AddReserva(ReservaInput input, [Service] IReservaRepository repository)
    {
        var reserva = new Reserva
        {
            DataHora = DateTime.Now,
            NomeCliente = input.NomeCliente,
            NumeroPessoas = input.NumeroPessoas,
            Observacoes = input.Observacoes
        };

        await repository.Add(reserva);
        return reserva;
    }

    public async Task<Reserva?> UpdateReserva(int id, ReservaInput input, [Service] IReservaRepository repository)
    {
        var reserva = new Reserva
        {
            NomeCliente = input.NomeCliente,
            NumeroPessoas = input.NumeroPessoas,
            Observacoes = input.Observacoes
        };

        return await repository.Update(id, reserva);
    }

    public async Task<bool> DeleteReserva(int id, [Service] IReservaRepository repository)
    {
        return await repository.Delete(id);
    }
}
