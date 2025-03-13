using Microsoft.EntityFrameworkCore;
using provasub.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar o serviço do Entity Framework
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

// Rota para teste na raiz
app.MapGet("/", () => "Prova sub");

// Cadastrar Produto
app.MapPost("/api/produto/cadastrar", async (Produto produto, AppDataContext context) =>
{
    context.Produtos.Add(produto);
    await context.SaveChangesAsync();
    return Results.Created($"/api/produto/{produto.Id}", produto);
});

// Listar Produtos (adicionando, caso precise testar depois)
app.MapGet("/api/produto/listar", async (AppDataContext context) =>
{
    return await context.Produtos.ToListAsync();
});

app.Run();
