using System;
using System.Collections.Generic;
using Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Example
    {
        [TestMethod]
        public void Case1()
        {
            string[] prods =
            {
                "1 book at 12.49",
                "1 music CD at 14.99",
                "1 chocolate bar at 0.85"
            };

            ShopingCart cart = ShopingCart.TryParse(prods);


            Assert.IsNotNull(cart);
            Assert.IsTrue(cart.NumProducts == 3);
            Assert.IsTrue(cart.GetProduct(0).FinalPrice == 12.49);
            Assert.IsTrue(cart.GetProduct(1).FinalPrice == 16.49);
            Assert.IsTrue(cart.GetProduct(2).FinalPrice == 0.85);
            Assert.IsTrue(cart.TotalTaxes == 1.50);
            Assert.IsTrue(cart.TotalPrice == 29.83);
        }

        [TestMethod]
        public void Case2()
        {
            string[] prods =
            {
                "1 imported box of chocolates at 10.00",
                "1 imported bottle of perfume at 47.50"
            };

            ShopingCart cart = ShopingCart.TryParse(prods);


            Assert.IsNotNull(cart);
            Assert.IsTrue(cart.NumProducts == 2);
            Assert.IsTrue(cart.GetProduct(0).FinalPrice == 10.50);
            Assert.IsTrue(cart.GetProduct(1).FinalPrice == 54.65);
            Assert.IsTrue(cart.TotalTaxes == 7.65);
            Assert.IsTrue(cart.TotalPrice == 65.15);
        }

        [TestMethod]
        public void Case3()
        {
            string[] prods =
            {
                "1 imported bottle of perfume at 27.99",
                "1 bottle of perfume at 18.99",
                "1 packet of headache pills at 9.75",
                "1 box of imported chocolates at 11.25"
            };

            ShopingCart cart = ShopingCart.TryParse(prods);


            Assert.IsNotNull(cart);
            Assert.IsTrue(cart.NumProducts == 4);
            Assert.IsTrue(cart.GetProduct(0).FinalPrice == 32.19);
            Assert.IsTrue(cart.GetProduct(1).FinalPrice == 20.89);
            Assert.IsTrue(cart.GetProduct(2).FinalPrice == 9.75);
            Assert.IsTrue(cart.GetProduct(3).FinalPrice == 11.85);
            Assert.IsTrue(cart.TotalTaxes == 6.70);
            Assert.IsTrue(cart.TotalPrice == 74.68);
        }
    }
}
