using RestaurantGraphQL.API.GraphQL.Inputs;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Mutations;

public class CategoriaMutation
{
    public async Task<Categoria> AddCategoria(CategoriaInput input, [Service] ICategoriaRepository repository)
    {
        var categoria = new Categoria { Nome = input.Nome };

        await repository.Add(categoria);

        return categoria;
    }
}