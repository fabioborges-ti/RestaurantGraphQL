namespace RestaurantGraphQL.API.GraphQL.Mutations.Base;

public class Mutation
{
    public CategoriaMutation Categorias => new();
    public MenuMutation Menus => new();
    public ReservaMutation Reservas => new();
}
