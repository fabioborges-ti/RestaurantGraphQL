using System.ComponentModel.DataAnnotations;

namespace RestaurantGraphQL.Core.Models;

public class Reserva
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomeCliente { get; set; } = string.Empty;

    [Required]
    public DateTime DataHora { get; set; }

    public int NumeroPessoas { get; set; }
    public string? Observacoes { get; set; }
}