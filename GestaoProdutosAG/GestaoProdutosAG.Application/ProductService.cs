using System;
using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.Domain.Models;
using GestaoProdutosAG.Domain.Services;

namespace GestaoProdutosAG.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductDbAdapter _productDbAdapter;

        public ProductService(IProductDbAdapter productDbAdapter)
        {
            _productDbAdapter = productDbAdapter;
        }

        public Product GetProductByCode(int productCode)
        {
            var result = _productDbAdapter.GetProduct(productCode);

            if (result == null)
                throw new InvalidOperationException($"Não econtrado produto com código {productCode}");

            return result;
        }

        public Product AddProduct(Product product)
        {
            if (product.ManufacturingDate >= product.ExpirationDate)
                throw new ArgumentException("Data de Fabricação não pode ser maior que a Data de Validade!");

            return _productDbAdapter.Add(product);
        }
    }
}
