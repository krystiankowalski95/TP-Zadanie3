using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace UnitTests
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void GetProductsWithoutCategoryTest()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext()) {
                List<Product> products = context.GetTable<Product>().ToList();
                List<Product> productsWithoutCategory = products.GetProductsWithoutCategory__QuerySyntax();
                Console.WriteLine(productsWithoutCategory.Count);
                Assert.AreEqual(productsWithoutCategory.Count, 209);
            }
        }

        [TestMethod]
        public void GetProductsWithoutCategoryMethodTest()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Product> products = context.GetTable<Product>().ToList();
                List<Product> productsWithoutCategory = products.GetProductsWithoutCategory__MethodSyntax();
                Console.WriteLine(productsWithoutCategory.Count);
                Assert.AreEqual(productsWithoutCategory.Count, 209);
            }
        }

        [TestMethod]
        public void DivideProductListToPages__QuerySyntaxTest()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Product> products = context.GetTable<Product>().ToList();
                List<Product> productsPaged = products.DivideProductListToPages__QuerySyntax(50,1);
                Console.WriteLine(productsPaged.Count);
                Assert.AreEqual(productsPaged.Count, 50);
            }
        }

        [TestMethod]
        public void DivideProductListToPages__MethodSyntaxTest()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Product> products = context.GetTable<Product>().ToList();
                List<Product> productsPaged = products.DivideProductListToPages__MethodSyntax(50, 1);
                Console.WriteLine(productsPaged.Count);
                Assert.AreEqual(productsPaged.Count, 50);
            }
        }


        [TestMethod]
        public void ProductsAndVendorsToString__MethodSyntaxTest()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Product> products = context.GetTable<Product>().ToList();
                List<ProductVendor> vendors = context.GetTable<ProductVendor>().ToList();
                String productString = products.ProductsAndVendorsToString__MethodSyntax(vendors);
                Console.WriteLine(productString);
                Assert.AreEqual(productString.Contains("Chainring Bolts-Training Systems"), true);
                Assert.AreEqual(productString.Contains("Flat Washer 6-Continental Pro Cycles"), true);
                Assert.AreEqual(productString.Contains("Decal 2-SUPERSALES INC."), true);
                Assert.AreEqual(productString.Contains("Hex Nut 19-Norstan Bike Hut"), true);
            }
        }

        [TestMethod]
        public void ProductsAndVendorsToString__QuerySyntaxTest()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Product> products = context.GetTable<Product>().ToList();
                List<ProductVendor> vendors = context.GetTable<ProductVendor>().ToList();
                String productString = products.ProductsAndVendorsToString__QuerySyntax(vendors);
                Console.WriteLine(productString);
                Assert.AreEqual(productString.Contains("Chainring Bolts-Training Systems"), true);
                Assert.AreEqual(productString.Contains("Flat Washer 6-Continental Pro Cycles"), true);
                Assert.AreEqual(productString.Contains("Decal 2-SUPERSALES INC."), true);
                Assert.AreEqual(productString.Contains("Hex Nut 19-Norstan Bike Hut"), true);
            }
        }


    }
}
