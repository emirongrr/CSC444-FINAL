using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Xml.Linq;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class CustomersViewModel : ObservableObject
    {
        public Customer SelectedCustomer { get; set; }

        public ICommand NavigateAddCustomerCommand { get; }
        public ICommand NavigateUpdateCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> CustomersList
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

    

        public void UpdateCustomersList()
        {
            Connect db = new Connect();
            CustomersList = db.GetCustomers();

        }

        public CustomersViewModel(MainViewModel mainViewModel)
        {
            CustomersList = new ObservableCollection<Customer>();
            Connect db = new Connect();
            CustomersList = db.GetCustomers();

            DeleteCustomerCommand = new DelegateCommand<Customer>(o =>
            {
                db.DeleteCustomer(o.Id.ToString());
                _ = CustomersList.Remove(o);
            });


            NavigateAddCustomerCommand = new RelayCommand(o =>
            {
                mainViewModel.CurrentView = new AddCustomerPageViewModel(mainViewModel);

            });


            NavigateUpdateCustomerCommand = new DelegateCommand<Customer>(o =>
            {
                UpdateCustomerPageViewModel updateCustomerPageViewModel = new UpdateCustomerPageViewModel(mainViewModel)
                {
                    CustomerId = o.Id,
                    CustomerName = o.Name,
                    CustomerLastName = o.LastName,
                    CustomerPhone = o.Phone,
                    CustomerAddress = o.Address
                };

                mainViewModel.CurrentView = updateCustomerPageViewModel;
            });

            
        }
    }
}
