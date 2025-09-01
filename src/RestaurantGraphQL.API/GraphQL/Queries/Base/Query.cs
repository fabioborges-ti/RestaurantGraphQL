namespace RestaurantGraphQL.API.GraphQL.Queries.Base;

public class Query
{
    public CategoriaQuery Categorias => new();
    public MenuQuery Menus => new();
    public ReservaQuery Reservas => new();
}
