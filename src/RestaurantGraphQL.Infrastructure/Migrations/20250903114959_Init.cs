using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantGraphQL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroPessoas = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Entradas" },
                    { 2, "Massas" },
                    { 3, "Carnes" },
                    { 4, "Peixes e Frutos do Mar" },
                    { 5, "Aves" },
                    { 6, "Saladas" },
                    { 7, "Sobremesas" },
                    { 8, "Bebidas" },
                    { 9, "Pratos Vegetarianos" },
                    { 10, "Menu Executivo" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "DataHora", "NomeCliente", "NumeroPessoas", "Observacoes" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), "João Silva", 2, "Mesa próxima à janela" },
                    { 2, new DateTime(2025, 9, 16, 20, 30, 0, 0, DateTimeKind.Unspecified), "Maria Oliveira", 4, "Aniversário, trazer bolo" },
                    { 3, new DateTime(2025, 9, 17, 18, 45, 0, 0, DateTimeKind.Unspecified), "Carlos Pereira", 3, "Preferência por mesa externa" },
                    { 4, new DateTime(2025, 9, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), "Fernanda Souza", 6, "Mesa para grupo, perto do bar" },
                    { 5, new DateTime(2025, 9, 19, 19, 30, 0, 0, DateTimeKind.Unspecified), "Ricardo Gomes", 2, "Pedido de vinho antecipado" },
                    { 6, new DateTime(2025, 9, 20, 20, 15, 0, 0, DateTimeKind.Unspecified), "Juliana Costa", 5, "Cadeiras extras para crianças" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CategoriaId", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 1, "Pão italiano tostado com tomate, manjericão fresco, alho e azeite extra virgem", "Bruschetta Italiana", 24.899999999999999 },
                    { 2, 1, "Fatias finas de salmão fresco com alcaparras, rúcula e molho de mostarda", "Carpaccio de Salmão", 32.899999999999999 },
                    { 3, 1, "Seleção de queijos nacionais e importados com salamis artesanais e geleia", "Tábua de Queijos e Embutidos", 45.899999999999999 },
                    { 4, 2, "Massa italiana com bacon, ovos, queijo parmesão e pimenta do reino", "Spaghetti à Carbonara", 38.899999999999999 },
                    { 5, 2, "Lasanha tradicional com molho bolonhesa, bechamel e queijo gratinado", "Lasanha Bolonhesa", 42.899999999999999 },
                    { 6, 2, "Massa fettuccine com molho cremoso de queijo parmesão e manteiga", "Fettuccine Alfredo", 36.899999999999999 },
                    { 7, 2, "Risotto cremoso com camarões frescos, alho-poró e vinho branco", "Risotto de Camarão", 54.899999999999999 },
                    { 8, 3, "Picanha nobre grelhada com farofa de banana, vinagrete e mandioca", "Picanha Grelhada", 67.900000000000006 },
                    { 9, 3, "Corte especial de bife ancho com batatas rústicas e molho chimichurri", "Bife Ancho Premium", 72.900000000000006 },
                    { 10, 3, "Costela bovina assada lentamente com molho barbecue especial da casa", "Costela BBQ", 58.899999999999999 },
                    { 11, 4, "Filé de salmão grelhado com legumes salteados e molho de ervas finas", "Salmão Grelhado", 64.900000000000006 },
                    { 12, 4, "Camarões refogados no leite de coco com dendê, pimentões e coentro", "Moqueca de Camarão", 59.899999999999999 },
                    { 13, 4, "Bacalhau desfiado com batatas, ovos, cebola e azeitonas portuguesas", "Bacalhau à Gomes de Sá", 68.900000000000006 },
                    { 14, 5, "Peito de frango empanado com molho de tomate e queijo gratinado", "Frango à Parmegiana", 44.899999999999999 },
                    { 15, 5, "Pato confitado lentamente com purê de batata-doce e molho de laranja", "Duck Confit", 78.900000000000006 },
                    { 16, 6, "Mix de folhas verdes, croutons, parmesão e molho caesar tradicional", "Salada Caesar", 28.899999999999999 },
                    { 17, 6, "Camarões grelhados sobre mix de folhas, tomate cereja e molho de maracujá", "Salada de Camarão", 42.899999999999999 },
                    { 18, 7, "Sobremesa italiana com café espresso, mascarpone e cacau em pó", "Tiramisù", 22.899999999999999 },
                    { 19, 7, "Bolo quente de chocolate com sorvete de baunilha e calda de chocolate", "Petit Gâteau", 26.899999999999999 },
                    { 20, 7, "Cheesecake cremoso com calda de frutas vermelhas e biscoito de baunilha", "Cheesecake de Frutas Vermelhas", 24.899999999999999 },
                    { 21, 8, "Vinho tinto nacional reserva, safra especial com notas frutadas", "Vinho Tinto Reserva", 89.900000000000006 },
                    { 22, 8, "Cachaça artesanal com limão siciliano e açúcar demerara", "Caipirinha Premium", 18.899999999999999 },
                    { 23, 8, "Suco natural de frutas da estação sem conservantes", "Suco Natural da Casa", 12.9 },
                    { 24, 9, "Massa folhada com mix de legumes da estação e queijo de cabra", "Quiche de Legumes", 32.899999999999999 },
                    { 25, 9, "Bowl nutritivo com quinoa, grão-de-bico, abacate e molho tahine", "Buddha Bowl", 34.899999999999999 },
                    { 26, 10, "Peito de frango grelhado, arroz, feijão, batata e salada", "Executivo - Frango Grelhado", 26.899999999999999 },
                    { 27, 10, "Peixe grelhado do dia com legumes, arroz e purê de batatas", "Executivo - Peixe do Dia", 29.899999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoriaId",
                table: "Menus",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
