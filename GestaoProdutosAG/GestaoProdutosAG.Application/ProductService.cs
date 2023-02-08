using System;
using System.Collections.Generic;
using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.Domain.Models;
using GestaoProdutosAG.Domain.Services;

namespace GestaoProdutosAG.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productDbAdapter;

        public ProductService(IProductRepository productDbAdapter)
        {
            _productDbAdapter = productDbAdapter;
        }

        public Product GetProductByCode(int productCode)
        {
            var result = _productDbAdapter.GetByCode(productCode);

            if (result == null)
                throw new InvalidOperationException($"Produto código {productCode} não encontrado!");

            return result;
        }

        public IEnumerable<Product> GetProductsList(
            bool? status,
            DateTime? manufactoringDate,
            DateTime? expirationDate,
            int? vendorCode,
            string? vendorDescription,
            int? vendorCNPJ,
            int pageNumber,
            int pageLength)
        {
            return _productDbAdapter.GetProductsList(
                status,
                manufactoringDate,
                expirationDate,
                vendorCode,
                vendorDescription,
                vendorCNPJ,
                pageNumber,
                pageLength);
        }

        public Product AddProduct(Product product)
        {
            if (product.ManufacturingDate >= product.ExpirationDate)
                throw new ArgumentException("Data de Fabricação não pode ser maior que a Data de Validade!");

            return _productDbAdapter.Add(product);
        }

        public Product UpdateProduct(Product product)
        {
            if (product.ManufacturingDate >= product.ExpirationDate)
                throw new ArgumentException("Data de Fabricação não pode ser maior que a Data de Validade!");

            return _productDbAdapter.Update(product);
        }

        public void DeleteProduct(int productCode)
        {
            _productDbAdapter.Deactivate(productCode);
        }
    }
}
