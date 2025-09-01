using Microsoft.EntityFrameworkCore;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<Reserva> Reservas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>()
            .HasOne(m => m.Categoria)
            .WithMany(c => c.Menus)
            .HasForeignKey(m => m.CategoriaId);
    }
}