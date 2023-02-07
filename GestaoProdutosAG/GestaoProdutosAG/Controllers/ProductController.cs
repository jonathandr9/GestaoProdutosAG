using System;
using System.Collections.Generic;
using AutoMapper;
using GestaoProdutosAG.API.Dto;
using GestaoProdutosAG.Domain.Models;
using GestaoProdutosAG.Domain.Services;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("GetProduct")]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        [ProducesResponseType(typeof(ProductViewModel), 200)]
        public IActionResult GetProduct([FromQuery] int codigoProduto)
        {
            try
            {
                var productReturn = _productService.GetProductByCode(codigoProduto);

                return Ok(_mapper.Map<ProductViewModel>(productReturn));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ErrorViewModel()
                {
                    ErrorCode = 1,
                    Description = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorViewModel()
                    {
                        ErrorCode = 500,
                        Description = ex.Message
                    });
            }
        }

        [HttpGet("GetProductsList")]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        [ProducesResponseType(typeof(ProductViewModel), 200)]
        public IActionResult GetProductsList(
            [FromQuery] bool? status,
            [FromQuery] DateTime? manufactoringDate,
            [FromQuery] DateTime? expirationDate,
            [FromQuery] int? vendorCode,
            [FromQuery] string? vendorDescription,
            [FromQuery] int? vendorCNPJ,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageLength = 20)
        {
            try
            {
                var productReturn = _productService.GetProductsList(
                    status,
                    manufactoringDate,
                    expirationDate,
                    vendorCode,
                    vendorDescription,
                    vendorCNPJ,
                    pageNumber,
                    pageLength);

                return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(productReturn));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ErrorViewModel()
                {
                    ErrorCode = 1,
                    Description = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorViewModel()
                    {
                        ErrorCode = 500,
                        Description = ex.Message
                    });
            }
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        [ProducesResponseType(typeof(ProductViewModel), 200)]
        public IActionResult AddProduct(ProductPost productPost)
        {
            try
            {
                var product = _mapper.Map<Product>(productPost);

                var productReturn = _productService.AddProduct(product);

                return Ok(_mapper.Map<ProductViewModel>(productReturn));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorViewModel()
                {
                    ErrorCode = 1,
                    Description = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorViewModel()
                    {
                        ErrorCode = 500,
                        Description = ex.Message
                    });
            }
        }


        [HttpPut("Update")]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        [ProducesResponseType(typeof(ProductViewModel), 200)]
        public IActionResult UpdateProduct(ProductPost productPost)
        {
            try
            {
                var product = _mapper.Map<Product>(productPost);

                var productReturn = _productService.AddProduct(product);

                return Ok(_mapper.Map<ProductViewModel>(productReturn));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorViewModel()
                {
                    ErrorCode = 1,
                    Description = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorViewModel()
                    {
                        ErrorCode = 500,
                        Description = ex.Message
                    });
            }
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        [ProducesResponseType(typeof(ProductViewModel), 200)]
        public IActionResult DeleteProduct(int productCode)
        {
            try
            {

                _productService.DeleteProduct(productCode);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorViewModel()
                    {
                        ErrorCode = 500,
                        Description = ex.Message
                    });
            }
        }
    }
}
