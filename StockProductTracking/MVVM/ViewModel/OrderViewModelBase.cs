using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.ViewModel
{
    internal abstract class OrderViewModelBase : ObservableObject, IDataErrorInfo
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
        public int OrderProductCount { get; set; }
        public bool OrderStatus { get; set; }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "OrderProductCount")
                {

                    if (!(this.OrderProductCount > 0))
                        result = "En az 1 adet satın almalısınız.";

                }

                return result;
            }
        }

    }
}
