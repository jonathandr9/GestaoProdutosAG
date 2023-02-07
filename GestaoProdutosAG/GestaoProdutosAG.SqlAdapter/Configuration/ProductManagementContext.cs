using GestaoProdutosAG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAG.DbAdapter.Configuration
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext() : base()
        {

        }

        public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

    }
}
