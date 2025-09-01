using System.ComponentModel.DataAnnotations;

namespace RestaurantGraphQL.API.GraphQL.Inputs;

public record ReservaInput([Required] string NomeCliente, [Required] DateTime DataHora, int NumeroPessoas, string? Observacoes);