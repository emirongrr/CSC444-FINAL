using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using System.Linq.Expressions;
using System;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Windows.Data;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class CustomersViewModel : ObservableViewDataObject
    {
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
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public void UpdateCustomersList()
        {
            CustomersList = new ObservableCollection<Customer>();
            Connect db = new Connect();
            CustomersList = db.GetCustomers();
            CollectionView = CollectionViewSource.GetDefaultView(CustomersList);

        }
        public override bool SearchFilter(object o)
        {
            Customer customer = o as Customer;
            if (customer == null || SearchKey == null)
                return false;
            return SearchKey.Trim() == String.Empty || customer.GetFullName.ToLower().Contains(SearchKey.Trim().ToLower()) || customer.Address.ToLower().Contains(SearchKey.Trim().ToLower()) || customer.Address.ToLower().Contains(SearchKey.Trim().ToLower()) || customer.Phone.ToLower().Contains(SearchKey.Trim().ToLower());
        }
        public CustomersViewModel(MainViewModel mainViewModel)
        {
            CustomersList = new ObservableCollection<Customer>();
            Connect db = new Connect();
            CustomersList = db.GetCustomers();
            CollectionView = CollectionViewSource.GetDefaultView(CustomersList);

            DeleteCustomerCommand = new DelegateCommand<Customer>(o =>
            {
                try
                {
                    db.DeleteCustomer(o.Id.ToString());
                    _ = CustomersList.Remove(o);
                    Message = " ";
                }
                catch(Exception e)
                {
                    Message = "Onaylanmýþ sipariþi olan müþteri silinemez";
                    Console.WriteLine(e.Message);
                }
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
                    CustomerAddress = o.Address,
                    CheckPhone = o.Phone
                };
                mainViewModel.CurrentView = updateCustomerPageViewModel;
            });
        }
    }
}
