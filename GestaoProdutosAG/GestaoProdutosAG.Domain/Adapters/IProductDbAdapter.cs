using GestaoProdutosAG.Domain.Models;
using System;
using System.Collections.Generic;

namespace GestaoProdutosAG.Domain.Adapters
{
    public interface IProductDbAdapter
    {
        Product GetByCode(int code);
        Product Add(Product product);
        IEnumerable<Product> GetProductsList(
            bool? status,
            DateTime? manufactoringDate,
            DateTime? expirationDate,
            int? vendorCode,
            string? vendorDescription,
            int? vendorCNPJ,
            int pageNumber,
            int pageLength);
        Product Update(Product product);
        void Deactivate(int code);
    }
}
