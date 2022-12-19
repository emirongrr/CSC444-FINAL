using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockProductTracking.MVVM.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductBrand { get; set; }
        public string ProductPrice { get; set; } //satış
        public string ProductRealPrice { get; set; } //alış
        public int ProductStock { get; set; }


    }
}
