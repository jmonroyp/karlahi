using System;
using Xunit;
using Moq;
using KarlaHi.Infrastructure.Entities;
using KarlaHi.Core.Services;
using KarlaHi.Api.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace KarlaHi.Tests
{
    public class ProductsTest
    {
        #region Property  
        public Mock<IProductsService> mock = new Mock<IProductsService>();
        #endregion
        [Fact]
        public async void GetProduct()
        {
            mock.Setup(p => p.GetProduct(666)).ReturnsAsync(new Product()
            {
                Id = 666,
                Name = "Moq"
            });
            ProductsController prod = new ProductsController(mock.Object);
            var res = await prod.GetProduct(666);

            Assert.Equal(666, res.Id);
        }

        [Fact]
        public async void GetProductsList()
        {
            mock.Setup(p => p.GetProductsList()).ReturnsAsync(
            new List<Product>() {
                    new Product() {
                        Id = 666,
                        Name = "Moq"
                     },
                     new Product() {
                        Id = 333,
                        Name = "Moq2"
                    }
                }
           );
            ProductsController prod = new ProductsController(mock.Object);
            var res = await prod.GetProducts();

            Assert.Equal(2, res.Count());
        }
    }
}
