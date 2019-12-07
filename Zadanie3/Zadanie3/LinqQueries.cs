using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class LinqQueries
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Table<Product> table = context.GetTable<Product>();
                List<Product> products = (from product in table
                                          where product.Name.Contains(namePart)
                                          select product).ToList();
                return products;
            }
            

        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Table<ProductVendor> table = context.GetTable<ProductVendor>();
                List<Product> products = (from vendor in table
                                          where vendor.Vendor.Name.Equals(vendorName)
                                          select vendor.Product).ToList();
                return products;
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Table<ProductVendor> table = context.GetTable<ProductVendor>();
                List<String> productNames = (from vendor in table
                                          where vendor.Vendor.Name.Equals(vendorName)
                                          select vendor.Product.Name).ToList();
                return productNames;
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Table<ProductVendor> table = context.GetTable<ProductVendor>();
                string name  = (from vendor in table
                               where vendor.Product.Name.Equals(productName)
                               select vendor.Vendor.Name).ToList()[0];
                return name;
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Table<Product> table = context.GetTable<Product>();
                List<Product> products = (from product in table
                                          where product.ProductReview.Count.Equals(howManyReviews)
                                          select product).ToList();
                return products;
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Table<ProductReview> table = context.GetTable<ProductReview>();
                List<Product> products = (from review in table
                                          orderby review.ReviewDate
                                          select review.Product).Take(howManyProducts).ToList();
                return products;
            }
        }


    }
}
