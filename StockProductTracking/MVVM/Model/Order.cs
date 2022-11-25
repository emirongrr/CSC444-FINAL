using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderProductTitle { get; set; }
        public int OrderProductPrice { get; set; }
        public int OrderProductCount { get; set; }
        public bool OrderStatus { get; set; }

    }
}
