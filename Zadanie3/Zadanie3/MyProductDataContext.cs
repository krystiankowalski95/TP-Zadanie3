using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProductDataContext
    {
        public List<MyProduct> myProducts { get; set; }

        public MyProductDataContext(DataClasses1DataContext dataContext)
        {
            this.myProducts = dataContext.Product.AsEnumerable().Select(product => new MyProduct(product)).ToList();
        }

    }
}
