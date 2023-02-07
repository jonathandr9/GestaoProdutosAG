using GestaoProdutosAG.Application;
using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.Domain.Models;
using GestaoProdutosAG.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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

            _productDbAdapterMock.Setup(x => x.GetByCode(It.IsAny<int>())
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

            _productDbAdapterMock.Setup(x => x.GetByCode(It.IsAny<int>())
               ).Returns(product);

            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            //Act / Assert
            Assert.Throws<InvalidOperationException>(() => productService.GetProductByCode(1));
        }

        [Fact]
        [Trait("GetProductsList", "Product")]
        public void GetProductList_ProdutService_Success()
        {
            //Arrange          
            var list = new List<Product>()
            {
                new Product{
                    Code = 1,
                    Description = "",
                    Status = true,
                    ManufacturingDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(30),
                    VendorCode = 1,
                    VendorDescription = "Fornecedor 1",
                    VendorCNPJ = 000033564444
                },
                new Product{
                    Code = 1,
                    Description = "",
                    Status = true,
                    ManufacturingDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(30),
                    VendorCode = 1,
                    VendorDescription = "Fornecedor 1",
                    VendorCNPJ = 000033564444
                }
            };

            _productDbAdapterMock.Setup(x => x.GetProductsList(
                It.IsAny<bool?>(),
                It.IsAny<DateTime?> (),
                It.IsAny<DateTime?> (),
                It.IsAny<int?>(),
                It.IsAny<string?>(),
                It.IsAny<int?>(),
                It.IsAny<int>(),
                It.IsAny<int>())
                ).Returns(list);

            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            //Act      
            var returnProduct = productService.GetProductsList(
                null,
                null,
                null,
                null,
                null,
                null,
                0,
                20);

            //Assert
            Assert.True(returnProduct.ToList().Count == 2);
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


            //Act / Assert
            Assert.Throws<ArgumentException>(() => productService.AddProduct(product));
        }


        [Fact]
        [Trait("UpdateProduct", "Product")]
        public void UpdateProduct_ProdutService_Success()
        {
            //Arrange          
            var productUpdate = new Product()
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

            var productReturn = productUpdate;
            productReturn.Code = 1;

            _productDbAdapterMock.Setup(x => x.Update(It.IsAny<Product>())
                ).Returns(productReturn);

            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            //Act      
            var returnProduct = productService.UpdateProduct(productUpdate);

            //Assert
            Assert.True(returnProduct.Code == 1);
        }


        [Fact]
        [Trait("UpdateProduct", "Product")]
        public void UpdateProduct_ProdutService_ErrorManufacturingGreaterValidity()
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


            _productDbAdapterMock.Setup(x => x.Update(product));
            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            //Act / Assert
            Assert.Throws<ArgumentException>(() => productService.UpdateProduct(product));
        }

        [Fact]
        [Trait("UpdateProduct", "Product")]
        public void DeleteProduct_ProdutService()
        {
            //Arrange       
            int productCode = 1;

            _productDbAdapterMock.Setup(x => x.Deactivate(It.IsAny<int>()));
            IProductService productService = new ProductService(_productDbAdapterMock.Object);

            //Act
            try
            {
                productService.DeleteProduct(productCode);
            }

            //Assert
            catch (Exception)
            {
                Assert.False(true);
            }
            finally
            {
                Assert.True(true);
            }
        }

    }
}
