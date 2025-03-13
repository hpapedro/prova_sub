using Microsoft.EntityFrameworkCore;

namespace provasub.Models;

public class AppDataContext : DbContext{
    public required DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

}