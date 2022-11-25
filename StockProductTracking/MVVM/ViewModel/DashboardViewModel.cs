using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class DashboardViewModel : ObservableObject
    {
        private DashboardHandler dashboardHandler = new DashboardHandler();
        private readonly Connect connect = new Connect();

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
        private GraphAxis _YAxis;
        public GraphAxis YAxis
        {
            get => _YAxis;
            set
            {
                _YAxis = value;
                OnPropertyChanged();
            }
        }

        private GraphAxis _XAxis;
        public GraphAxis XAxis
        {
            get => _XAxis;
            set
            {
                _XAxis = value;
                OnPropertyChanged();
            }
        }
        public ChartValues<Double> ChartValues
        { 
            get => dashboardHandler.ChartValues;
            set 
            {
                dashboardHandler.ChartValues = value;
                OnPropertyChanged();
            } 
        }
        public void UpdateDashboard()
        {
            SumTotalPrice = connect.GetTotalPriceOrders() + "₺";
            CountTotalOrder = connect.GetTotalOrderCount() + "Adet";
            dashboardHandler.SetChartDataToProfit();
        }

        public DashboardViewModel(MainViewModel mainViewModel)
        {
            UpdateDashboard();
         
            YAxis = new GraphAxis(1.2 * ChartValues.Max());
            XAxis = new GraphAxis(Convert.ToDouble(connect.GetTotalOrderCount()));

            DispatcherTimer dispatcherTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 1, 0) //h,m,s
            };
            dispatcherTimer.Tick += new EventHandler((object sender, EventArgs e) =>
            {
                UpdateDashboard();
            });
            dispatcherTimer.Start();
        }
    }
}
