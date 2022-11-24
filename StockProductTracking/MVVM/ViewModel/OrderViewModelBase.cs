using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.ViewModel
{
    internal abstract class OrderViewModelBase : ObservableObject
    {
        private Product currentProduct = new Product();
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderProductTitle
        {
            get { return currentProduct.ProductTitle; }
            set { currentProduct.ProductTitle = value; }
        }
        public int OrderProductPrice
        {
            get { return currentProduct.ProductPrice; }
            set { currentProduct.ProductPrice = value; }
        }
        public int OrderProductCount { get; set;}
        public bool OrderStatus { get; set; }

    }
}
