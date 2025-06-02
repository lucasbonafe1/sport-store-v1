using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IconCSS = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeUsuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CarrinhoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ImagemUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarrinhoId = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoItens_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carrinhos",
                columns: new[] { "Id", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "IconCSS", "Nome" },
                values: new object[,]
                {
                    { 1, "", "Equipamentos" },
                    { 2, "", "Eletrônicos Esportivos" },
                    { 3, "", "Roupas" },
                    { 4, "", "Calçados" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { 1, null, "Bonafe" },
                    { 2, null, "Lucas" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "ImagemUrl", "Nome", "Preco", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, "Bola oficial para jogos, costurada à máquina e resistente à água", "/Imagens/Esportes/bola1.jpg", "Bola de Futebol Adidas", 120m, 50 },
                    { 2, 1, "Bola de basquete para quadra indoor/outdoor", "/Imagens/Esportes/bola2.jpg", "Bola de Basquete Wilson", 95m, 60 },
                    { 3, 1, "Raquete profissional leve e resistente para jogadores intermediários", "/Imagens/Esportes/raquete.jpg", "Raquete de Tênis Babolat", 350m, 20 },
                    { 4, 1, "Rede oficial com medidas para torneios profissionais", "/Imagens/Esportes/rede_volei.jpg", "Rede de Vôlei Profissional", 200m, 15 },
                    { 5, 1, "Capacete ajustável com ventilação para maior segurança", "/Imagens/Esportes/capacete.jpg", "Capacete para Ciclismo", 180m, 30 },
                    { 6, 2, "Relógio esportivo com GPS e monitoramento cardíaco", "/Imagens/Esportes/garmin.jpg", "Smartwatch Garmin", 1100m, 25 },
                    { 7, 2, "Fones bluetooth resistentes à água com ótima fixação", "/Imagens/Esportes/fone.jpg", "Fone Esportivo JBL", 320m, 80 },
                    { 8, 2, "Multiesportivo com sensores precisos de desempenho", "/Imagens/Esportes/polar.jpg", "Relógio Polar Vantage M", 900m, 40 },
                    { 9, 3, "Camiseta leve com tecnologia de secagem rápida", "/Imagens/Esportes/camiseta.jpg", "Camiseta Dry Fit Nike", 120m, 100 },
                    { 10, 3, "Legging feminina ideal para treinos e corridas", "/Imagens/Esportes/legging.jpg", "Calça Legging Adidas", 150m, 70 },
                    { 11, 3, "Shorts com tecido respirável e elástico", "/Imagens/Esportes/shorts.jpg", "Shorts Esportivo Under Armour", 90m, 80 },
                    { 12, 4, "Tênis leve e confortável com amortecimento em gel", "/Imagens/Esportes/tenis_asics.jpg", "Tênis de Corrida Asics", 350m, 40 },
                    { 13, 4, "Chuteira profissional para campo", "/Imagens/Esportes/chuteira.jpg", "Chuteira Nike Mercurial", 450m, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_ProdutoId",
                table: "CarrinhoItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CarrinhoId",
                table: "Usuarios",
                column: "CarrinhoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoItens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
