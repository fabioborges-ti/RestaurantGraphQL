using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantGraphQL.Core.Models;

public class Menu
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    public Categoria Categoria { get; set; } = null!;
}
