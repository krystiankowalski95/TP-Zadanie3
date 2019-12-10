using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProductRepository
    {
        private MyProductDataContext context;

        public MyProductRepository(MyProductDataContext context)
        {
            this.context = context;
        }

        public List<MyProduct> GetProductsByName(string nameContains)
        {
            return (from product in context.myProducts
                    where product.Name.ToLower().Contains(nameContains.ToLower())
                    select product).ToList();
        }


        public List<MyProduct> GetNProductsFromCategory(string categoryName, int n)
        {
            return (from product in context.myProducts
                    where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select product).Take(n).ToList();
        }


        public List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return (from product in context.myProducts
                    where product.ProductReview.Count == howManyReviews
                    select product).ToList();
        }
    }
}
