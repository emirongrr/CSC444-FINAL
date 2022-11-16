using StockProductTracking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.ViewModel
{
    internal abstract class CategoryViewModelBase : ObservableObject
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        
    }
}
