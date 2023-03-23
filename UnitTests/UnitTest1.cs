using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebUI.Controllers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Can_Paginte()
        //{
        //    Mock<IProductRepository> mock = new Mock<IProductRepository>();
        //    mock.Setup(m => m.Products).Returns(new Product[]{
        //        new Product { ProductID = 1, Name = "P1" },
        //        new Product { ProductID = 2, Name = "P2" },
        //        new Product { ProductID = 3, Name = "P3" },
        //        new Product { ProductID = 4, Name = "P4" },
        //        new Product { ProductID = 5, Name = "P5" },
        //        new Product { ProductID = 6, Name = "P6" }
        //    });

        //    ProductController controller = new ProductController(mock.Object);
        //    controller.PageSize = 3;

        //    IEnumerable<Product> result = (IEnumerable<Product>)controller.List(null, 2).Model;

        //    Product[] prodArray = result.ToArray();
        //    Assert.IsTrue(prodArray.Length == 3);
        //    Assert.AreEqual(prodArray[0].Name, "P4");
        //    Assert.AreEqual(prodArray[1].Name, "P4");
        //}

        [TestMethod]
        public void Can_Add_New_Lines()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 10 };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 20 };
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 30 };
            
            Cart cart = new Cart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 2);
            cart.AddItem(p3, 3);
            cart.AddItem(p3, 3);

            CartLine[] result = cart.Lines.ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0].Product, p1);
            Assert.AreEqual(result[1].Product, p2);
            Assert.AreEqual(result[2].Product, p3);

            Assert.AreEqual(result[2].Quantity, 6);

            cart.RemoveItem(p2);
            result = cart.Lines.ToArray();
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Product, p1);
            Assert.AreEqual(result[1].Product, p3);

            Assert.AreEqual(cart.ComputeTotalValue(), (decimal)190.00);

            cart.Clear();
            result = cart.Lines.ToArray();
            Assert.AreEqual(result.Length, 0);
        }
    }
}
