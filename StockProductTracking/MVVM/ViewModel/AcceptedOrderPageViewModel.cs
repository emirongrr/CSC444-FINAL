using System;
using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using System.Windows.Data;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class AcceptedOrderPageViewModel : ObservableViewDataObject
    {
        private ObservableCollection<Order> acceptedOrdersList;
        public ObservableCollection<Order> AcceptedOrdersList
        {
            get { return acceptedOrdersList; }
            set
            {
                acceptedOrdersList = value;
                OnPropertyChanged(nameof(AcceptedOrdersList));
            }
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
        public AcceptedOrderPageViewModel(MainViewModel mainViewModel)
        {
            UpdateOrderList();
        }

        public void UpdateOrderList()
        {
            AcceptedOrdersList = new ObservableCollection<Order>();
            Connect db = new Connect();
            AcceptedOrdersList = db.GetAcceptedOrders();
            CollectionView = CollectionViewSource.GetDefaultView(acceptedOrdersList);
        }
    }
}
