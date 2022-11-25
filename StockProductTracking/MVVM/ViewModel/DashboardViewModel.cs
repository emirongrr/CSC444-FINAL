using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class DashboardViewModel : ObservableObject
    {

        private string _sumtotalprice;
        public string SumTotalPrice
        {
            get => _sumtotalprice;
            set
            {
                _sumtotalprice = value;
                OnPropertyChanged();
            }
        }

        private string _counttotalprice;
        public string CountTotalOrder
        {
            get => _counttotalprice;
            set
            {
                _counttotalprice = value;
                OnPropertyChanged();
            }
        }

        public void UpdateDashboard()
        {
            Connect coneect = new Connect();
            SumTotalPrice =  coneect.GetTotalPriceOrders() + "₺";
            CountTotalOrder = coneect.GetTotalOrderCount() + "Adet";

        }

        public DashboardViewModel(MainViewModel mainViewModel)
        {
            Connect coneect = new Connect();
            SumTotalPrice =  coneect.GetTotalPriceOrders() + "₺" ;
            CountTotalOrder = coneect.GetTotalOrderCount() + " Adet";
            
        }
    }
}
