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
    }
}
