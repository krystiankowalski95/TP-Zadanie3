using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class ExtensionMethods
    {
        public static List<Product> GetProductsWithoutCategory__QuerySyntax(this List<Product> list)
        {
            List<Product> products = (from product in list
                                      where product.ProductSubcategory == null
                                      select product).ToList();
            return products;
        }

        public static List<Product> DivideProductListToPages__QuerySyntax(this List<Product> list, int productsPerPage, int pageNumber)
        {
            List<Product> products = (from product in list
                                      select product).Skip((pageNumber - 1) * productsPerPage).Take(productsPerPage).ToList();
            return products;
        }

        public static string ProductsAndVendorsToString__QuerySyntax(this List<Product> products, List<ProductVendor> productVendors)
        {

            StringBuilder stringBuilder = new StringBuilder();

            var pairs = from product in products
                        from productVendor in productVendors
                        where productVendor.ProductID == product.ProductID
                        select new { Product = product.Name, Vendor = productVendor.Vendor.Name };
 
            foreach (var pair in pairs)
            {
                stringBuilder.Append(pair.Product).Append("-").Append(pair.Vendor).Append("\n");
            }
            return stringBuilder.ToString();
        }
        
        public static List<Product> GetProductsWithoutCategory__MethodSyntax(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategory == null).ToList();
        }

        public static List<Product> DivideProductListToPages__MethodSyntax(this List<Product> products, int size, int pageNumber)
        {
            return products.Skip((pageNumber - 1) * size).Take(size).ToList();
        }

        public static string ProductsAndVendorsToString__MethodSyntax(this List<Product> products, List<ProductVendor> productVendors)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var pairs = products.Join(productVendors, product => product.ProductID, vendor => vendor.ProductID, (product, productVendor) 
                => new { Product = product.Name, Vendor = productVendor.Vendor.Name });

            foreach (var pair in pairs)
            {
                stringBuilder.Append(pair.Product).Append("-").Append(pair.Vendor).Append("\n");
            }
            return stringBuilder.ToString();
        }





    }
}
