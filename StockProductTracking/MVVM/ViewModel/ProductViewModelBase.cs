using StockProductTracking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.ViewModel
{
    internal abstract class ProductViewModelBase : ObservableObject
    {
        public int ProductId { get; set; }
        public int CategoryID { get; set; }
        public string ProductTitle { get; set; }
        public string ProductBrand { get; set; }
        public int ProductPrice { get; set; }   
        public int ProductRealPrice { get; set; }
        public int ProductStock { get; set; }

    }
}
