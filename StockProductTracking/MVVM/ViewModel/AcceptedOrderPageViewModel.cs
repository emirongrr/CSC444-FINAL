using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class AcceptedOrderPageViewModel : ObservableObject
    {
        private ObservableCollection<Order> acceptedOrdersList;
        public ObservableCollection<Order> AcceptedOrdersList
        {
            get { return acceptedOrdersList; }
            set
            {
                acceptedOrdersList = value;
                OnPropertyChanged();
            }
        }

        public AcceptedOrderPageViewModel(MainViewModel mainViewModel)
        {
            AcceptedOrdersList = new ObservableCollection<Order>();
            UpdateOrderList();
        }

        public void UpdateOrderList()
        {
            Connect db = new Connect();
            AcceptedOrdersList = db.GetAcceptedOrders();
            
        }

    }
}
