using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class AddOrderPageViewModel : OrderViewModelBase
    {
        public ICommand AddOrderCommand { get; }



        public AddOrderPageViewModel(MainViewModel mainViewModel)
        {

            AddOrderCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.AddOrder(CustomerId,OrderProductTitle,OrderProductPrice,OrderProductCount,OrderStatus);
                mainViewModel.OrderVM.UpdateOrderList();
            });

        }
    }
}
