using GestaoProdutosAG.Application;
using GestaoProdutosAG.Domain.Adapters;
using GestaoProdutosAG.Domain.Models;
using GestaoProdutosAG.Domain.Services;
using GestaoProdutosAG.SqlAdapter;
using System;
using Xunit;

namespace GestaoProdutosAG.Tests
{
    public class ProductsServiceTests
    {
        [Fact]
        [Trait("AddProduct", "Product")]
        public void AddProduct_ProdutsService_Success()
        {
            //Arrange          
            var product = new Product();

            Moq.Mock<ProductDbAdapter> productDbAdapterMock = new Moq.Mock<ProductDbAdapter>();
            productDbAdapterMock.Setup(x => x.Add(product));
            IProductService productService = new ProductService(productDbAdapterMock.Object);

            //Act
            try
            {
                productService.AddProduct(product);
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
