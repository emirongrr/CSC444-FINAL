using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;
using System;
using System.Windows.Data;
using System.Diagnostics.Contracts;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class OrdersViewModel : ObservableViewDataObject
    {
        public Order SelectedOrder { get; set; }

        public ICommand NavigateAddOrderCommand { get; }
        public ICommand SetOrderToAccepted { get; }
        public ICommand DeleteOrderCommand { get; }
        public ICommand NavigateAcceptedOrderCommand { get; }

        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> OrdersList
        {
            get => orders;
            set
            {
                orders = value;
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

        public void UpdateOrderList()
        {
            Connect db = new Connect();
            OrdersList = db.GetOrders();
            CollectionView = CollectionViewSource.GetDefaultView(OrdersList);
        }
        public override bool SearchFilter(object o)
        {
            Order order = o as Order;
            if (order == null || SearchKey == null)
                return false;
            if (Int32.TryParse(SearchKey, out _))
            {
                int key = Convert.ToInt32(SearchKey);
                return key == order.CustomerId || key == order.OrderId;
            }
            return SearchKey.Trim() == string.Empty || order.OrderProductTitle.ToLower().Contains(SearchKey.ToLower().Trim());
        }
        public OrdersViewModel(MainViewModel mainViewModel)
        {
            OrdersList = new ObservableCollection<Order>();
            Connect db = new Connect();
            OrdersList = db.GetOrders();
            CollectionView = CollectionViewSource.GetDefaultView(OrdersList);

            DeleteOrderCommand = new DelegateCommand<Order>(o =>
            {               
               db.DeleteOrder(o.OrderId.ToString());
               _ = OrdersList.Remove(o);      
            });


            NavigateAddOrderCommand = new RelayCommand(o =>
            {
                mainViewModel.CurrentView = new AddOrderPageViewModel(mainViewModel);
            });

            SetOrderToAccepted = new DelegateCommand<Order>(order =>
            {
                try
                {
                    db.SetStatusToAccepted(order.OrderId);
                    _ = OrdersList.Remove(order);
                    //update accepted list
                    mainViewModel.AcceptedOrderPageVM.UpdateOrderList();
                    mainViewModel.DashboardVM.UpdateDashboard();
                    Message = " ";
                }
                catch (Exception e)
                {
                    Message = "Yeteri kadar stok yok";
                }
            });

            NavigateAcceptedOrderCommand = new RelayCommand(o =>
            {
                mainViewModel.CurrentView = mainViewModel.AcceptedOrderPageVM;
            });

        }
    }
}