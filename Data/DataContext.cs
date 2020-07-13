using SponteBackEnd.Data.Maps;
using Microsoft.EntityFrameworkCore;
using SponteBackEnd.Models;

namespace SponteBackEnd.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=SponteBackEnd;User ID=SA;Password=Cilage123");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new CategoriaMap());
            builder.Entity<ProdutoCategoria>()
                .ToTable("Produto_Categoria")
                .HasKey(sc => new { sc.ProdutoId, sc.CategoriaId});
        }
    }
}