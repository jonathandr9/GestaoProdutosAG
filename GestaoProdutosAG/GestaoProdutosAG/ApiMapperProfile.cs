using AutoMapper;
using GestaoProdutosAG.API.Dto;
using GestaoProdutosAG.Domain.Models;

namespace GestaoProdutosAG.API
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<ProductPost, Product>()
                .ForMember(d => d.Description, m => m.MapFrom(s => s.Descricao))
                .ForMember(d => d.Status, m => m.MapFrom(s => s.Situacao))
                .ForMember(d => d.ManufacturingDate, m => m.MapFrom(s => s.DataFabricacao))
                .ForMember(d => d.ExpirationDate, m => m.MapFrom(s => s.DataValidade))
                .ForMember(d => d.VendorCode, m => m.MapFrom(s => s.CodigoFornecedor))
                .ForMember(d => d.VendorDescription, m => m.MapFrom(s => s.DescricaoFornecedor))
                .ForMember(d => d.VendorCNPJ, m => m.MapFrom(s => s.CNPJFornecedor));
        }
    }
}
