using Microsoft.EntityFrameworkCore;

namespace FirstASPMvc.Models
{
    public class Context : DbContext
    {
        public DbSet<Category> Categorias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Action<NpgsqlDbContextOptionsBuilder> configuracaoDeConexao = 
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=15432;Username=postgres;Password=123456;Database=teste_db_aspnet");
        }
    }
}