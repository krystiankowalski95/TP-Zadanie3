using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace UnitTests
{
    [TestClass]
    public class MyProductCollectionTest
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                MyProductDataContext context = new MyProductDataContext(db);
                MyProductRepository repository = new MyProductRepository(context);
                List<MyProduct> products = repository.GetProductsByName("Washer");
                Assert.AreEqual(products.Count, 42);
                
            }
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                MyProductDataContext context = new MyProductDataContext(db);
                MyProductRepository repository = new MyProductRepository(context);
                List<MyProduct> products = repository.GetNProductsFromCategory("Clothing", 6);
                Assert.AreEqual(products.Count, 6);
                foreach (Product product in products)
                    Assert.AreEqual(product.ProductSubcategory.ProductCategory.Name, "Clothing");
            }
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                MyProductDataContext context = new MyProductDataContext(db);
                MyProductRepository repository = new MyProductRepository(context);
                List<MyProduct> products = repository.GetProductsWithNRecentReviews(1);
                Assert.AreEqual(products.Count, 2);
                Assert.IsNotNull(products.Find(product => product.ProductID == 709));
                Assert.IsNotNull(products.Find(product => product.ProductID == 798));
            }
        }

    }
}
