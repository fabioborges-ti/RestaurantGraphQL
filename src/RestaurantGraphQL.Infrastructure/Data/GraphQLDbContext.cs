using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using RestaurantGraphQL.Core.Models;

public class GraphQLDbContext : DbContext
{
    public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options) { }

    public DbSet<Menu> Menus { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Menu>()
            .HasOne(m => m.Categoria)
            .WithMany(c => c.Menus)
            .HasForeignKey(m => m.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        CategorySeedData.SeedCategories(modelBuilder);
        MenuSeedData.SeedMenus(modelBuilder);
        ReservationData.SeedReservations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    public static class CategorySeedData
    {
        public static void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    Id = 1,
                    Nome = "Entradas",
                },
                new Categoria
                {
                    Id = 2,
                    Nome = "Massas",
                },
                new Categoria
                {
                    Id = 3,
                    Nome = "Carnes",
                },
                new Categoria
                {
                    Id = 4,
                    Nome = "Peixes e Frutos do Mar",
                },
                new Categoria
                {
                    Id = 5,
                    Nome = "Aves",
                },
                new Categoria
                {
                    Id = 6,
                    Nome = "Saladas",
                },
                new Categoria
                {
                    Id = 7,
                    Nome = "Sobremesas",
                },
                new Categoria
                {
                    Id = 8,
                    Nome = "Bebidas",
                },
                new Categoria
                {
                    Id = 9,
                    Nome = "Pratos Vegetarianos",
                },
                new Categoria
                {
                    Id = 10,
                    Nome = "Menu Executivo",
                }
            );
        }
    }

    public static class MenuSeedData
    {
        public static void SeedMenus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(
                // ENTRADAS (Categoria 1)
                new Menu
                {
                    Id = 1,
                    Nome = "Bruschetta Italiana",
                    Descricao = "Pão italiano tostado com tomate, manjericão fresco, alho e azeite extra virgem",
                    Preco = 24.90,
                    CategoriaId = 1
                },
                new Menu
                {
                    Id = 2,
                    Nome = "Carpaccio de Salmão",
                    Descricao = "Fatias finas de salmão fresco com alcaparras, rúcula e molho de mostarda",
                    Preco = 32.90,
                    CategoriaId = 1
                },
                new Menu
                {
                    Id = 3,
                    Nome = "Tábua de Queijos e Embutidos",
                    Descricao = "Seleção de queijos nacionais e importados com salamis artesanais e geleia",
                    Preco = 45.90,
                    CategoriaId = 1
                },
                new Menu
                {
                    Id = 4,
                    Nome = "Spaghetti à Carbonara",
                    Descricao = "Massa italiana com bacon, ovos, queijo parmesão e pimenta do reino",
                    Preco = 38.90,
                    CategoriaId = 2
                },
                new Menu
                {
                    Id = 5,
                    Nome = "Lasanha Bolonhesa",
                    Descricao = "Lasanha tradicional com molho bolonhesa, bechamel e queijo gratinado",
                    Preco = 42.90,
                    CategoriaId = 2
                },
                new Menu
                {
                    Id = 6,
                    Nome = "Fettuccine Alfredo",
                    Descricao = "Massa fettuccine com molho cremoso de queijo parmesão e manteiga",
                    Preco = 36.90,
                    CategoriaId = 2
                },
                new Menu
                {
                    Id = 7,
                    Nome = "Risotto de Camarão",
                    Descricao = "Risotto cremoso com camarões frescos, alho-poró e vinho branco",
                    Preco = 54.90,
                    CategoriaId = 2
                },
                new Menu
                {
                    Id = 8,
                    Nome = "Picanha Grelhada",
                    Descricao = "Picanha nobre grelhada com farofa de banana, vinagrete e mandioca",
                    Preco = 67.90,
                    CategoriaId = 3
                },
                new Menu
                {
                    Id = 9,
                    Nome = "Bife Ancho Premium",
                    Descricao = "Corte especial de bife ancho com batatas rústicas e molho chimichurri",
                    Preco = 72.90,
                    CategoriaId = 3
                },
                new Menu
                {
                    Id = 10,
                    Nome = "Costela BBQ",
                    Descricao = "Costela bovina assada lentamente com molho barbecue especial da casa",
                    Preco = 58.90,
                    CategoriaId = 3
                },
                new Menu
                {
                    Id = 11,
                    Nome = "Salmão Grelhado",
                    Descricao = "Filé de salmão grelhado com legumes salteados e molho de ervas finas",
                    Preco = 64.90,
                    CategoriaId = 4
                },
                new Menu
                {
                    Id = 12,
                    Nome = "Moqueca de Camarão",
                    Descricao = "Camarões refogados no leite de coco com dendê, pimentões e coentro",
                    Preco = 59.90,
                    CategoriaId = 4
                },
                new Menu
                {
                    Id = 13,
                    Nome = "Bacalhau à Gomes de Sá",
                    Descricao = "Bacalhau desfiado com batatas, ovos, cebola e azeitonas portuguesas",
                    Preco = 68.90,
                    CategoriaId = 4
                },
                new Menu
                {
                    Id = 14,
                    Nome = "Frango à Parmegiana",
                    Descricao = "Peito de frango empanado com molho de tomate e queijo gratinado",
                    Preco = 44.90,
                    CategoriaId = 5
                },
                new Menu
                {
                    Id = 15,
                    Nome = "Duck Confit",
                    Descricao = "Pato confitado lentamente com purê de batata-doce e molho de laranja",
                    Preco = 78.90,
                    CategoriaId = 5
                },
                new Menu
                {
                    Id = 16,
                    Nome = "Salada Caesar",
                    Descricao = "Mix de folhas verdes, croutons, parmesão e molho caesar tradicional",
                    Preco = 28.90,
                    CategoriaId = 6
                },
                new Menu
                {
                    Id = 17,
                    Nome = "Salada de Camarão",
                    Descricao = "Camarões grelhados sobre mix de folhas, tomate cereja e molho de maracujá",
                    Preco = 42.90,
                    CategoriaId = 6
                },
                new Menu
                {
                    Id = 18,
                    Nome = "Tiramisù",
                    Descricao = "Sobremesa italiana com café espresso, mascarpone e cacau em pó",
                    Preco = 22.90,
                    CategoriaId = 7
                },
                new Menu
                {
                    Id = 19,
                    Nome = "Petit Gâteau",
                    Descricao = "Bolo quente de chocolate com sorvete de baunilha e calda de chocolate",
                    Preco = 26.90,
                    CategoriaId = 7
                },
                new Menu
                {
                    Id = 20,
                    Nome = "Cheesecake de Frutas Vermelhas",
                    Descricao = "Cheesecake cremoso com calda de frutas vermelhas e biscoito de baunilha",
                    Preco = 24.90,
                    CategoriaId = 7
                },
                new Menu
                {
                    Id = 21,
                    Nome = "Vinho Tinto Reserva",
                    Descricao = "Vinho tinto nacional reserva, safra especial com notas frutadas",
                    Preco = 89.90,
                    CategoriaId = 8
                },
                new Menu
                {
                    Id = 22,
                    Nome = "Caipirinha Premium",
                    Descricao = "Cachaça artesanal com limão siciliano e açúcar demerara",
                    Preco = 18.90,
                    CategoriaId = 8
                },
                new Menu
                {
                    Id = 23,
                    Nome = "Suco Natural da Casa",
                    Descricao = "Suco natural de frutas da estação sem conservantes",
                    Preco = 12.90,
                    CategoriaId = 8
                },
                new Menu
                {
                    Id = 24,
                    Nome = "Quiche de Legumes",
                    Descricao = "Massa folhada com mix de legumes da estação e queijo de cabra",
                    Preco = 32.90,
                    CategoriaId = 9
                },
                new Menu
                {
                    Id = 25,
                    Nome = "Buddha Bowl",
                    Descricao = "Bowl nutritivo com quinoa, grão-de-bico, abacate e molho tahine",
                    Preco = 34.90,
                    CategoriaId = 9
                },
                new Menu
                {
                    Id = 26,
                    Nome = "Executivo - Frango Grelhado",
                    Descricao = "Peito de frango grelhado, arroz, feijão, batata e salada",
                    Preco = 26.90,
                    CategoriaId = 10
                },
                new Menu
                {
                    Id = 27,
                    Nome = "Executivo - Peixe do Dia",
                    Descricao = "Peixe grelhado do dia com legumes, arroz e purê de batatas",
                    Preco = 29.90,
                    CategoriaId = 10
                }
            );
        }
    }

    public static class ReservationData
    {
        public static void SeedReservations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>().HasData(
                new Reserva
                {
                    Id = 1,
                    NomeCliente = "João Silva",
                    DataHora = new DateTime(2025, 9, 15, 19, 0, 0),
                    NumeroPessoas = 2,
                    Observacoes = "Mesa próxima à janela",
                },
                new Reserva
                {
                    Id = 2,
                    NomeCliente = "Maria Oliveira",
                    DataHora = new DateTime(2025, 9, 16, 20, 30, 0),
                    NumeroPessoas = 4,
                    Observacoes = "Aniversário, trazer bolo",
                },
                new Reserva
                {
                    Id = 3,
                    NomeCliente = "Carlos Pereira",
                    DataHora = new DateTime(2025, 9, 17, 18, 45, 0),
                    NumeroPessoas = 3,
                    Observacoes = "Preferência por mesa externa",
                },
                new Reserva
                {
                    Id = 4,
                    NomeCliente = "Fernanda Souza",
                    DataHora = new DateTime(2025, 9, 18, 21, 0, 0),
                    NumeroPessoas = 6,
                    Observacoes = "Mesa para grupo, perto do bar",
                },
                new Reserva
                {
                    Id = 5,
                    NomeCliente = "Ricardo Gomes",
                    DataHora = new DateTime(2025, 9, 19, 19, 30, 0),
                    NumeroPessoas = 2,
                    Observacoes = "Pedido de vinho antecipado",
                },
                new Reserva
                {
                    Id = 6,
                    NomeCliente = "Juliana Costa",
                    DataHora = new DateTime(2025, 9, 20, 20, 15, 0),
                    NumeroPessoas = 5,
                    Observacoes = "Cadeiras extras para crianças",
                }
            );
        }
    }
}
