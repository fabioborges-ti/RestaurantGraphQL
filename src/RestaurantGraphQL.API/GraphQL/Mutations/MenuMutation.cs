using RestaurantGraphQL.API.GraphQL.Inputs;
using RestaurantGraphQL.Core.Interfaces.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.API.GraphQL.Mutations
{
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
    }
}