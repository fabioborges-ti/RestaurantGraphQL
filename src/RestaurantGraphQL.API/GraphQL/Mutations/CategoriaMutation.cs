using RestaurantGraphQL.API.GraphQL.Inputs;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class CategoriaMutation
{
    public async Task<Categoria> AddCategoria(CategoriaInput input, [Service] ICategoriaRepository repository)
    {
        var categoria = new Categoria { Nome = input.Nome };
        await repository.Add(categoria);
        return categoria;
    }

    public async Task<bool> UpdateCategoria(int id, CategoriaInput input, [Service] ICategoriaRepository repository)
    {
        var categoria = new Categoria { Id = id, Nome = input.Nome };

        return await repository.Update(categoria);
    }

    public async Task<bool> DeleteCategoria(int id, [Service] ICategoriaRepository repository)
    {
        return await repository.Delete(id);
    }
}
