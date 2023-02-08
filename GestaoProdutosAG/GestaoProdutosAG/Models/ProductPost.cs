using System;

namespace GestaoProdutosAG.API.Models
{
    public class ProductPost
    {
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public int CNPJFornecedor { get; set; }
    }
}
