using GestaoProdutosAG.DbAdapter.Configuration;
using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.Domain.Models;

namespace GestaoProdutosAG.SqlAdapter
{
    public class ProductDbAdapter : IProductDbAdapter
    {
        private readonly ProductManagementContext _context;
        public ProductDbAdapter(ProductManagementContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }
    }
}
