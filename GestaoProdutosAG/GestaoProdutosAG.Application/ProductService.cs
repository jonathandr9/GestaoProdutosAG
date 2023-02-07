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

        public void AddProduct(Product product)
        {
            if (product.ManufacturingDate >= product.ExpirationDate)
                throw new Exception("Data de Fabricação não pode ser maior que a Data de Validade!");

            _productDbAdapter.Add(product);
        }
    }
}
