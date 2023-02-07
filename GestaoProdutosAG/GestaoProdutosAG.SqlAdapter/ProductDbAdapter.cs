using GestaoProdutosAG.DbAdapter.Configuration;
using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.Domain.Models;
using System.Linq;

namespace GestaoProdutosAG.SqlAdapter
{
    public class ProductDbAdapter : IProductDbAdapter
    {
        private readonly ProductManagementContext _context;
        public ProductDbAdapter(ProductManagementContext context)
        {
            _context = context;
        }

        public Product GetProduct(int code)
        {
            return _context.Products.FirstOrDefault(p => p.Code == code);
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }
    }
}
