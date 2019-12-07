using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = LinqQueries.GetProductsByName("Flat");
            foreach(Product product in products)
            {
                Console.WriteLine(product.ProductID + " , " + product.Name);
            }
        }
    }
}
