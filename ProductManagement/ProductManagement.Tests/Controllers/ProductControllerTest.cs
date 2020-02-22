using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement;
using ProductManagement.Controllers;
using ProductManagement.Data;
using ProductManagement.Repositories;

namespace ProductManagement.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        public IProductRepository ProductRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        Product prod = new Product
        {
            CategoryID = 1,
            ProductName = "Product Name1",
            Description = "Product Name1 Description",
            UnitPrice = 12
        };
        [TestMethod]
        public void ProductsList()
        {
            // Arrange
            ProductController controller = new ProductController(ProductRepository,CategoryRepository);

            // Act
            ViewResult result = controller.ProductsList("","","",null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        [HttpPost]
        public void AddProduct()
        {
            
            // Arrange
            ProductController controller = new ProductController(ProductRepository, CategoryRepository);

            // Act
            ViewResult result = controller.AddProduct(prod) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
