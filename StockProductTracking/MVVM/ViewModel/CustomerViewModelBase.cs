using StockProductTracking.Core;

namespace StockProductTracking.MVVM.ViewModel
{
    internal abstract class CustomerViewModelBase : ObservableObject
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
    }
}
