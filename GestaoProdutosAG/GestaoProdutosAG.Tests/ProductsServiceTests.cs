using GestaoProdutosAG.Application;
using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.Domain.Models;
using GestaoProdutosAG.Domain.Services;
using Moq;
using System;
using Xunit;

namespace GestaoProdutosAG.Tests
{
    public class ProductsServiceTests
    {
        private readonly Mock<IProductDbAdapter> _productDbAdapterMock;
        public ProductsServiceTests()
        {
            _productDbAdapterMock = new Mock<IProductDbAdapter>();
        }


        [Fact]
        [Trait("GetProductByCode", "Product")]
        public void GetProduct_ProdutService_Success()
        {
            //Arrange          
            var productReturn = new Product()
            {
                Code = 1,
                Description = "",
                Status = true,
                ManufacturingDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                VendorCode = 1,
                VendorDescription = "Fornecedor 1",
                VendorCNPJ = 000033564444
            };

            _productDbAdapterMock.Setup(x => x.GetProduct(It.IsAny<int>())
                ).Returns(productReturn);

            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            //Act      
            var returnProduct = productService.GetProductByCode(1);

            //Assert
            Assert.True(returnProduct.Code == 1);
        }

        [Fact]
        [Trait("GetProductByCode", "Product")]
        public void GetProduct_ProdutService_ErrorProductNotFound()
        {
            //Arrange       
            Product product = null;

            _productDbAdapterMock.Setup(x => x.GetProduct(It.IsAny<int>())
               ).Returns(product);

            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            //Act / Assert
            Assert.Throws<InvalidOperationException>(() => productService.GetProductByCode(1));
        }

        [Fact]
        [Trait("AddProduct", "Product")]
        public void AddProduct_ProdutService_Success()
        {
            //Arrange          
            var productAdd = new Product()
            {
                Description = "",
                Status = true,
                ManufacturingDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                VendorCode = 1,
                VendorDescription = "Fornecedor 1",
                VendorCNPJ = 000033564444
            };

            var productReturn = productAdd;
            productReturn.Code = 1;

            _productDbAdapterMock.Setup(x => x.Add(It.IsAny<Product>())
                ).Returns(productReturn);

            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            //Act      
            var returnProduct = productService.AddProduct(productAdd);

            //Assert
            Assert.True(returnProduct.Code == 1);
        }


        [Fact]
        [Trait("AddProduct", "Product")]
        public void AddProduct_ProdutService_ErrorManufacturingGreaterValidity()
        {
            //Arrange       
            var product = new Product()
            {
                Description = "",
                Status = true,
                ManufacturingDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(-1),
                VendorCode = 1,
                VendorDescription = "Fornecedor 1",
                VendorCNPJ = 000033564444
            };


            _productDbAdapterMock.Setup(x => x.Add(product));
            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            _productDbAdapterMock.Setup(x => x.Add(product));

            //Act / Assert
            Assert.Throws<ArgumentException>(() => productService.AddProduct(product));
        }

    }
}
