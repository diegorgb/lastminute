﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void Parse()
        {
            List<Product> lstProd = ProductParser.ParseLine("1 book at 12.49");
            Assert.IsNotNull(lstProd);
            Assert.IsTrue(lstProd.Count == 1);
            Assert.IsTrue(lstProd[0] is Book);
        }

        [TestMethod]
        public void ParseImported()
        {
            List<Product> lstProd = ProductParser.ParseLine("1 imported book at 12.49");
            Assert.IsNotNull(lstProd);
            Assert.IsTrue(lstProd.Count == 1);
            Assert.IsTrue(lstProd[0] is Book);
            Assert.IsTrue(lstProd[0].Imported);
        }

        [TestMethod]
        public void BasicTaxes()
        {
            List<Product> lstProd = ProductParser.ParseLine("1 book at 12.49");
            double taxes = lstProd[0].CalculateTaxes();
            Assert.IsTrue(taxes == 0);
        }

        [TestMethod]
        public void ImportTaxes()
        {
            List<Product> lstProd = ProductParser.ParseLine("1 imported book at 12.49");
            double taxes = lstProd[0].CalculateTaxes();
            Assert.IsTrue(taxes == 0.65);
        }
    }
}
