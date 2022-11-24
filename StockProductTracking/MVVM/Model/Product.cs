using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductBrand { get; set; }
        public int ProductPrice { get; set; } //buy
        public int ProductRealPrice { get; set; } //sell
        public int ProductStock { get; set; }


    }
}
