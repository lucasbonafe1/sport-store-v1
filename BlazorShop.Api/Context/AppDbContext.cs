using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Carrinho>? Carrinhos { get; set; }
    public DbSet<CarrinhoItem>? CarrinhoItens { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Produtos - Esportes
        // Categoria: Equipamentos Esportivos
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 1,
            Nome = "Bola de Futebol Adidas",
            Descricao = "Bola oficial para jogos, costurada à máquina e resistente à água",
            ImagemUrl = "/Imagens/Esportes/bola1.jpg",
            Preco = 120,
            Quantidade = 50,
            CategoriaId = 1
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 2,
            Nome = "Bola de Basquete Wilson",
            Descricao = "Bola de basquete para quadra indoor/outdoor",
            ImagemUrl = "/Imagens/Esportes/bola2.jpg",
            Preco = 95,
            Quantidade = 60,
            CategoriaId = 1
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 3,
            Nome = "Raquete de Tênis Babolat",
            Descricao = "Raquete profissional leve e resistente para jogadores intermediários",
            ImagemUrl = "/Imagens/Esportes/raquete.jpg",
            Preco = 350,
            Quantidade = 20,
            CategoriaId = 1
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 4,
            Nome = "Rede de Vôlei Profissional",
            Descricao = "Rede oficial com medidas para torneios profissionais",
            ImagemUrl = "/Imagens/Esportes/rede_volei.jpg",
            Preco = 200,
            Quantidade = 15,
            CategoriaId = 1
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 5,
            Nome = "Capacete para Ciclismo",
            Descricao = "Capacete ajustável com ventilação para maior segurança",
            ImagemUrl = "/Imagens/Esportes/capacete.jpg",
            Preco = 180,
            Quantidade = 30,
            CategoriaId = 1
        });

        // Categoria: Eletrônicos Esportivos
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 6,
            Nome = "Smartwatch Garmin",
            Descricao = "Relógio esportivo com GPS e monitoramento cardíaco",
            ImagemUrl = "/Imagens/Esportes/garmin.jpg",
            Preco = 1100,
            Quantidade = 25,
            CategoriaId = 2
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 7,
            Nome = "Fone Esportivo JBL",
            Descricao = "Fones bluetooth resistentes à água com ótima fixação",
            ImagemUrl = "/Imagens/Esportes/fone.jpg",
            Preco = 320,
            Quantidade = 80,
            CategoriaId = 2
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 8,
            Nome = "Relógio Polar Vantage M",
            Descricao = "Multiesportivo com sensores precisos de desempenho",
            ImagemUrl = "/Imagens/Esportes/polar.jpg",
            Preco = 900,
            Quantidade = 40,
            CategoriaId = 2
        });

        // Categoria: Roupas Esportivas
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 9,
            Nome = "Camiseta Dry Fit Nike",
            Descricao = "Camiseta leve com tecnologia de secagem rápida",
            ImagemUrl = "/Imagens/Esportes/camiseta.jpg",
            Preco = 120,
            Quantidade = 100,
            CategoriaId = 3
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 10,
            Nome = "Calça Legging Adidas",
            Descricao = "Legging feminina ideal para treinos e corridas",
            ImagemUrl = "/Imagens/Esportes/legging.jpg",
            Preco = 150,
            Quantidade = 70,
            CategoriaId = 3
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 11,
            Nome = "Shorts Esportivo Under Armour",
            Descricao = "Shorts com tecido respirável e elástico",
            ImagemUrl = "/Imagens/Esportes/shorts.jpg",
            Preco = 90,
            Quantidade = 80,
            CategoriaId = 3
        });

        // Categoria: Calçados Esportivos
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 12,
            Nome = "Tênis de Corrida Asics",
            Descricao = "Tênis leve e confortável com amortecimento em gel",
            ImagemUrl = "/Imagens/Esportes/tenis_asics.jpg",
            Preco = 350,
            Quantidade = 40,
            CategoriaId = 4
        });
        modelBuilder.Entity<Produto>().HasData(new Produto
        {
            Id = 13,
            Nome = "Chuteira Nike Mercurial",
            Descricao = "Chuteira profissional para campo",
            ImagemUrl = "/Imagens/Esportes/chuteira.jpg",
            Preco = 450,
            Quantidade = 30,
            CategoriaId = 4
        });

        // Usuários
        modelBuilder.Entity<Usuario>().HasData(new Usuario
        {
            Id = 1,
            NomeUsuario = "Bonafe"
        });
        modelBuilder.Entity<Usuario>().HasData(new Usuario
        {
            Id = 2,
            NomeUsuario = "Lucas"
        });

        // Carrinho
        modelBuilder.Entity<Carrinho>().HasData(new Carrinho
        {
            Id = 1,
            UsuarioId = "1"
        });
        modelBuilder.Entity<Carrinho>().HasData(new Carrinho
        {
            Id = 2,
            UsuarioId = "2"
        });

        // Categorias
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Equipamentos" },
            new Categoria { Id = 2, Nome = "Eletrônicos Esportivos" },
            new Categoria { Id = 3, Nome = "Roupas" },
            new Categoria { Id = 4, Nome = "Calçados" }
        );
    }

}