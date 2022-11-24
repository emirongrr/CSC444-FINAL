using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class OrdersViewModel : ObservableObject
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

        public void UpdateOrderList()
        {
            Connect db = new Connect();
            OrdersList = db.GetOrders();

        }

        public OrdersViewModel(MainViewModel mainViewModel)
        {
            OrdersList = new ObservableCollection<Order>();
            Connect db = new Connect();
            OrdersList = db.GetOrders();

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
                db.SetStatusToAccepted(order.OrderId);
                _ = OrdersList.Remove(order);
                //update accepted list
                mainViewModel.AcceptedOrderPageVM.UpdateOrderList();
            });

            NavigateAcceptedOrderCommand = new RelayCommand(o =>
            {
                mainViewModel.CurrentView = mainViewModel.AcceptedOrderPageVM;
            });

        }
    }
}