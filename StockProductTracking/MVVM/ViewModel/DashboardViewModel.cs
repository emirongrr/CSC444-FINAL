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
        private SeriesCollection _chartSeries;
        public SeriesCollection ChartSeries
        {
            get => _chartSeries;
            set
            {
                _chartSeries = value;
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
        public void UpdateDashboard()
        {
            SumTotalPrice = connect.GetTotalPriceOrders() + "₺";
            CountTotalOrder = connect.GetTotalOrderCount() + "Adet";
            ChartSeries = new DashboardHandler().GetChartData();
        }

        public DashboardViewModel(MainViewModel mainViewModel)
        {
            YAxis = new GraphAxis(0, 2500);

            UpdateDashboard();
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
