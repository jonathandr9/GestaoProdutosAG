using AutoMapper;
using GestaoProdutosAG.API.Dto;
using GestaoProdutosAG.Domain.Models;
using GestaoProdutosAG.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutosAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(
            IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductPost productPost)
        {
            var product = _mapper.Map<Product>(productPost);

            _productService.AddProduct(product);

            return Ok();
        }
    }
}
