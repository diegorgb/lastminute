using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend;

namespace UnitTests
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void ParseBook()
        {
            Product prod = ProductParser.ParseLine("1 book at 12.49");
            Assert.IsTrue(prod is Book);
        }
    }
}
