using GestaoProdutosAG.Domain.Models;
using System;
using System.Collections.Generic;

namespace GestaoProdutosAG.Domain.Services
{
    public interface IProductService
    {
        Product GetProductByCode(int productCode);
        IEnumerable<Product> GetProductsList(
            bool? status,
            DateTime? manufactoringDate,
            DateTime? expirationDate,
            int? vendorCode,
            string? vendorDescription,
            int? vendorCNPJ,
            int pageNumber,
            int pageLength);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int productCode);
    }
}
