using GestaoProdutosAG.DbAdapter.Configuration;
using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoProdutosAG.SqlAdapter
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagementContext _context;
        public ProductRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public Product GetByCode(int code)
        {
            return _context.Products.FirstOrDefault(p => p.Code == code);
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

            IQueryable<Product> query = _context.Products;

            if (status != null)
                query = query.Where(q => q.Status == status);

            if (manufactoringDate != null)
                query = query.Where(q => q.ManufacturingDate == manufactoringDate);

            if (expirationDate != null)
                query = query.Where(q => q.ExpirationDate == expirationDate);

            if (vendorCode != null)
                query = query.Where(q => q.VendorCode == vendorCode);
            
            if (vendorDescription != null)
                query = query.Where(q => q.VendorDescription.Contains(vendorDescription));

            if (vendorCNPJ != null)
                query = query.Where(q => q.VendorCNPJ == vendorCNPJ);

            return query.AsNoTracking()
                .ToList()
                .Skip((pageNumber - 1) * pageLength)
                .Take(pageLength);
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Product Update(Product product)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Products.Update(product);
                    _context.SaveChanges();

                    return product;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException(ex.Message);
                }
            }
        }

        public void Deactivate(int code)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw($@"
                            UPDATE Product
                                SET Status = 0
                            WHERE Code = {code}");

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException(ex.Message);
                }
            }
        }
    }
}
