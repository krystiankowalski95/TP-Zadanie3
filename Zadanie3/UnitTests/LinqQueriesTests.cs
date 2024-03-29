﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using System.Collections.Generic;
using System.Data.Linq;

namespace UnitTests
{
    [TestClass]
    public class LinqQueriesTests
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = LinqQueries.GetProductsByName("Flat");
            Assert.AreEqual(products.Count, 9);
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            List<Product> products = LinqQueries.GetProductsByVendorName("Beaumont Bikes");
            Assert.AreEqual(products.Capacity, 4);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            List<Product> products = LinqQueries.GetProductsWithNRecentReviews(1);
            Assert.AreEqual(products.Capacity, 4);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            string name = LinqQueries.GetProductVendorByProductName("Flat Washer 1");
            Assert.AreEqual(name, "Continental Pro Cycles");
        }


        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            List<String> productNames = LinqQueries.GetProductNamesByVendorName("Continental Pro Cycles");
            Assert.AreEqual(productNames.Count, 9);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            List<Product> products = LinqQueries.GetNRecentlyReviewedProducts(2);
            Assert.AreEqual(products.Count, 2);
            
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            List<Product> products = LinqQueries.GetNProductsFromCategory("Bikes",25);
            Assert.AreEqual(products.Count, 25);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategory testCategory = new ProductCategory();
            testCategory.Name = "Bikes";

            DataClasses1DataContext context = new DataClasses1DataContext();
            int value = LinqQueries.GetTotalStandardCostByCategory(testCategory);
            Assert.AreEqual(value, 92093);
        }
    }
}
