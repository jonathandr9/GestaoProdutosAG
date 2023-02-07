using GestaoProdutosAG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAG.Domain.Adapters
{
    public interface IProductDbAdapter
    {
        void Add(Product product);
    }
}
