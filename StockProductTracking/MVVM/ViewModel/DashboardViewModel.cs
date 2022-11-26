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
        private DashboardGraphHandler dashboardGraphHandler = new DashboardGraphHandler();
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
        public GraphAxis YAxis
        {
            get => dashboardGraphHandler.YAxis;
            set
            {
                dashboardGraphHandler.YAxis = value;
                OnPropertyChanged();
            }
        }
        public GraphAxis XAxis
        {
            get => dashboardGraphHandler.XAxis;
            set
            {
                dashboardGraphHandler.XAxis = value;
                OnPropertyChanged();
            }
        }
        public ChartValues<Double> ChartValues
        { 
            get => dashboardGraphHandler.ChartValues;
            set 
            {
                dashboardGraphHandler.ChartValues = value;
                OnPropertyChanged();
            } 
        }
        public SeriesCollection PieChartSeries
        {
            get => dashboardGraphHandler.PieChartSeriesCollection;
            set
            {
                dashboardGraphHandler.PieChartSeriesCollection = value;
                OnPropertyChanged();
            }
        }
        public void UpdateDashboard()
        {
            SumTotalPrice = connect.GetTotalPriceOrders() + "₺";
            CountTotalOrder = connect.GetTotalOrderCount() + "Adet";
            dashboardGraphHandler.SetLineChartDataToProfit();
            dashboardGraphHandler.SetPieChartDataByCategories();
        }

        public DashboardViewModel(MainViewModel mainViewModel)
        {
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
