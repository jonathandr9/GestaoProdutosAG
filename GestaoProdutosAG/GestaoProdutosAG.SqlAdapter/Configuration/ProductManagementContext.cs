using GestaoProdutosAG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestaoProdutosAG.DbAdapter.Configuration
{
    public class ProductManagementContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options,
            IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteConnection"));
    }
}
