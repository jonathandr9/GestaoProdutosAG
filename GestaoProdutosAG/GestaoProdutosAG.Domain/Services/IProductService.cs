using GestaoProdutosAG.Domain.Models;

namespace GestaoProdutosAG.Domain.Services
{
    public interface IProductService
    {
        Product GetProductByCode(int productCode);
        Product AddProduct(Product product);
    }
}
