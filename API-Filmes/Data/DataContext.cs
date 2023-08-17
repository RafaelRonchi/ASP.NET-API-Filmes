using API_Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Filmes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<FilmeModel> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-H7EP5Q1\\SQLEXPRESS;database=filmedb;trusted_connection=true; TrustServerCertificate=True");
        }
    }
}
