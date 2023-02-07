using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoProdutosAG.Domain.Models
{
    public class Product
    {
        [Key]
        public int Code { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int VendorCode { get; set; }
        public string VendorDescription { get; set; }
        public int VendorCNPJ { get; set; }
    }
}
