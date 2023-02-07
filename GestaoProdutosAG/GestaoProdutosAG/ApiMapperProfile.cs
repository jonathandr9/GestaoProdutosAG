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

            CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.Codigo, m => m.MapFrom(s => s.Code))
                .ForMember(d => d.Descricao, m => m.MapFrom(s => s.Description))
                .ForMember(d => d.Situacao, m => m.MapFrom(s => s.Status))
                .ForMember(d => d.DataFabricacao, m => m.MapFrom(s => s.ManufacturingDate))
                .ForMember(d => d.DataValidade, m => m.MapFrom(s => s.ExpirationDate))
                .ForMember(d => d.CodigoFornecedor, m => m.MapFrom(s => s.VendorCode))
                .ForMember(d => d.DescricaoFornecedor, m => m.MapFrom(s => s.VendorDescription))
                .ForMember(d => d.CNPJFornecedor, m => m.MapFrom(s => s.VendorCNPJ));
        }
    }
}
