using System.ComponentModel.DataAnnotations;

namespace RestaurantGraphQL.Core.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    public ICollection<Menu>? Menus { get; set; }
}