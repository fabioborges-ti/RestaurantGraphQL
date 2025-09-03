using RestaurantGraphQL.API.GraphQL.Mutations.Inputs;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class MenuMutation
{
    public async Task<Menu> AddMenu(MenuInput input, [Service] IMenuRepository repository)
    {
        var menu = new Menu
        {
            Nome = input.Nome,
            Descricao = input.Descricao,
            Preco = input.Preco,
            CategoriaId = input.CategoriaId
        };

        await repository.Add(menu);
        return menu;
    }

    public async Task<bool> UpdateMenu(int id, MenuInput input, [Service] IMenuRepository repository)
    {
        var menu = new Menu
        {
            Id = id,
            Nome = input.Nome,
            Descricao = input.Descricao!,
            Preco = input.Preco,
            CategoriaId = input.CategoriaId
        };

        var result = await repository.Update(menu);
        return result;
    }

    public async Task<bool> DeleteMenuAsync(int id, [Service] IMenuRepository repository)
    {
        return await repository.Delete(id);
    }
}
