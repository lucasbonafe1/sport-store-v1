using BlazorShop.Api.Context;
using BlazorShop.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseCors(policy =>
//    policy.WithOrigins("http://localhost:7023", "https://localhost:7023", "http://localhost:32769")
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    .WithHeaders(HeaderNames.ContentType)
//);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
