using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class UpdateCustomerPageViewModel : CustomerViewModelBase
    {
        public ICommand UpdateCustomerCommand { get; }

        public UpdateCustomerPageViewModel(MainViewModel mainViewModel)
        {
            UpdateCustomerCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.UpdateCustomer(CustomerId, CustomerName, CustomerLastName, CustomerPhone, CustomerAddress);
                mainViewModel.CustomersVM.UpdateCustomersList();

            });
        }
    }
}
