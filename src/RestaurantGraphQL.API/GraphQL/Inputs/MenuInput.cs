namespace RestaurantGraphQL.API.GraphQL.Inputs;

public record MenuInput(string Nome, string Descricao, decimal Preco, int CategoriaId);