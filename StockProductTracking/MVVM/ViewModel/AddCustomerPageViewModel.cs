using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class AddCustomerPageViewModel : CustomerViewModelBase
    {
        public ICommand AddCustomerCommand { get; }

        public AddCustomerPageViewModel(MainViewModel mainViewModel)
        {

            AddCustomerCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.AddCustomer(CustomerName, CustomerLastName, CustomerPhone, CustomerAddress);
                mainViewModel.CustomersVM.UpdateCustomersList();
                mainViewModel.CurrentView = mainViewModel.CustomersVM;

            });

        }
    }
}
