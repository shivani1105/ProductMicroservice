using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NUnit.Framework;
using ProductMicroservice.Controllers;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ProductMicroserviceTesting
{
    public class Tests
    {
        List<Product> products;

        [SetUp]
        public void Setup()
        {
            products = new List<Product>()
            {
                new Product{ ProductId = 6, ProductName = "Product 6", Description = "This is Product 6", ImageName = "product6.jpg", Price = 4999, Rating = 4},
                new Product{ ProductId = 7, ProductName = "Product 7", Description = "This is Product 7", ImageName = "product7.jpg", Price = 2250, Rating = 3},
                new Product{ ProductId = 8, ProductName = "Product 8", Description = "This is Product 8", ImageName = "product8.jpg", Price = 6900, Rating = 5}
            };
        }

        [Test]
        public void GetAllProducts_ReturnsOkRequest()
        {

            var mock = new Mock<IProductRepository>();

            mock.Setup(x => x.GetAllProducts()).Returns(products);

            ProductController obj = new ProductController(mock.Object);

            var data = obj.GetAllProducts();

            var res = data as ObjectResult;

            TestContext.Progress.WriteLine("GetAllProducts_ReturnsOkRequest Test Method is Executed");

            Assert.AreEqual(StatusCodes.Status200OK, res.StatusCode);
        }
        [Test]
        public void GetAllProducts_ReturnsNotNullList()
        {
            var mock = new Mock<ProductRepository>();

            ProductController obj = new ProductController(mock.Object);

            var data = obj.GetAllProducts();

            Assert.IsNotNull(data);
        }

        [TestCase(9, StatusCodes.Status404NotFound)]
        [TestCase(8, StatusCodes.Status200OK)]
        [TestCase(7, StatusCodes.Status200OK)]
        public void Testing_SearchProductById(int id, int expectedCode)
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(x => x.SearchProductById(id)).Returns((products.Where(x => x.ProductId == id)).FirstOrDefault());

            ProductController obj = new ProductController(mock.Object);

            var data = obj.searchProductById(id);

            var statusCodeResult = (IStatusCodeActionResult)data;

            Assert.AreEqual(expectedCode, statusCodeResult.StatusCode);
        }

        [TestCase("Product 9", StatusCodes.Status404NotFound)]
        [TestCase("Product 8", StatusCodes.Status200OK)]
        [TestCase("Product 7", StatusCodes.Status200OK)]
        public void Testing_SearchProductByName(string name, int expectedCode)
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(x => x.SearchProductByName(name)).Returns((products.Where(x => x.ProductName == name)).FirstOrDefault());

            ProductController obj = new ProductController(mock.Object);

            var data = obj.searchProductByName(name);

            var statusCodeResult = (IStatusCodeActionResult)data;

            Assert.AreEqual(expectedCode, statusCodeResult.StatusCode);
        }

        [TestCase(9, 4, 0, StatusCodes.Status404NotFound)]
        [TestCase(8, 4, 1, StatusCodes.Status200OK)]
        [TestCase(7, 6, 1, StatusCodes.Status400BadRequest)]
        public void Testing_AddProductRating(int id, double rating, int result, int expectedCode)
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(x => x.AddProductRating(id, rating)).Returns(result);

            ProductController obj = new ProductController(mock.Object);

            var data = obj.AddProductRating(id, rating);

            var statusCodeResult = (IStatusCodeActionResult)data;

            Assert.AreEqual(expectedCode, statusCodeResult.StatusCode);
        }
    }
}