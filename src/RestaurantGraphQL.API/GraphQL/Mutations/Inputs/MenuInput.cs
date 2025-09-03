namespace RestaurantGraphQL.API.GraphQL.Mutations.Inputs;

public class MenuInput
{
    [GraphQLNonNullType]
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public int CategoriaId { get; set; }
}