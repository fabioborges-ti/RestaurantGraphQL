namespace RestaurantGraphQL.API.GraphQL.Mutations.Inputs;

public class MenuInput
{
    [GraphQLNonNullType]
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }
}