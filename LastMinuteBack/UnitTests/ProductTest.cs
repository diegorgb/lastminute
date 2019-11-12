using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Parse()
        {
            List<Product> lstProd = ProductParser.ParseLine("1 music CD at 14.99");
            Assert.IsNotNull(lstProd);
            Assert.IsTrue(lstProd.Count == 1);
            Assert.IsTrue(lstProd[0] is Product);
        }

        [TestMethod]
        public void ParseImported()
        {
            List<Product> lstProd = ProductParser.ParseLine("1 imported music CD at 14.99");
            Assert.IsNotNull(lstProd);
            Assert.IsTrue(lstProd.Count == 1);
            Assert.IsTrue(lstProd[0] is Product);
            Assert.IsTrue(lstProd[0].Imported);
        }

        [TestMethod]
        public void BasicTaxes()
        {
            List<Product> lstProd = ProductParser.ParseLine("1 music CD at 14.99");
            double taxes = lstProd[0].CalculateTaxes();
            Assert.IsTrue(taxes == 1.5);
        }

        [TestMethod]
        public void ImportTaxes()
        {
            List<Product> lstProd = ProductParser.ParseLine("1 imported music CD at 14.99");
            double taxes = lstProd[0].CalculateTaxes();
            Assert.IsTrue(taxes == 2.25);
        }
    }
}
