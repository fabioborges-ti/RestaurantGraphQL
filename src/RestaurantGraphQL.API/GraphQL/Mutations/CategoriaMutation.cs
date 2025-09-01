using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Mutations;

public class CategoriaMutation
{
    public async Task<Categoria> AddCategoria(string nome, [Service] ICategoriaRepository repository)
    {
        var categoria = new Categoria { Nome = nome };

        await repository.Add(categoria);

        return categoria;
    }
}