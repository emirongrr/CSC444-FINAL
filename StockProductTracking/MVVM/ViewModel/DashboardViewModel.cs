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
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class DashboardViewModel : ObservableObject
    {
        private DashboardGraphHandler dashboardGraphHandler = new DashboardGraphHandler();
        private readonly Connect connect = new Connect();
        private int _viewCount;
        public int ViewCount
        {
            get
            {
                return _viewCount;
            }
            set
            {
                _viewCount = value;
                OnPropertyChanged(nameof(ViewCount));
            }
        }
        private string _sumtotalprice;
        public string SumTotalPrice
        {
            get => _sumtotalprice;
            set
            {
                _sumtotalprice = value;
                OnPropertyChanged(nameof(SumTotalPrice));
            }
        }

        private string _counttotalprice;
        public string CountTotalOrder
        {
            get => _counttotalprice;
            set
            {
                _counttotalprice = value;
                OnPropertyChanged(nameof(CountTotalOrder));
            }
        }
        public GraphAxis YAxis
        {
            get => dashboardGraphHandler.YAxis;
            set
            {
                dashboardGraphHandler.YAxis = value;
                OnPropertyChanged(nameof(YAxis));
            }
        }
        public GraphAxis XAxis
        {
            get => dashboardGraphHandler.XAxis;
            set
            {
                dashboardGraphHandler.XAxis = value;
                OnPropertyChanged(nameof(XAxis));
            }
        }
        public ChartValues<Decimal> ChartValues
        { 
            get => dashboardGraphHandler.ChartValues;
            set 
            {
                dashboardGraphHandler.ChartValues = value;
                OnPropertyChanged(nameof(ChartValues));
            } 
        }
        private string CategoryTag { get; set; }
        private SeriesCollection pieChartSeries;
        public SeriesCollection PieChartSeries
        {
            get => pieChartSeries;
            set
            {
                pieChartSeries = value;
                OnPropertyChanged(nameof(PieChartSeries));
            }
        }
        public ICommand DrillDownCommand
        {
            get
            {
                return new RelayCommand(OnDrillDownCommand);
            }
        }
        private void OnDrillDownCommand(object chartPoint)
        {
            if(CategoryTag != null)
            {
                CategoryTag = null;
                UpdateDashboard();
            }
            else
            {
                CategoryTag = (chartPoint as ChartPoint).SeriesView.Title;
                PieChartSeries = dashboardGraphHandler.SetPieChartDataByProducts(CategoryTag);
            }
        }
        public void UpdateDashboard()
        {
            SumTotalPrice = connect.GetTotalPriceOrders() + "₺";
            CountTotalOrder = connect.GetTotalOrderCount() + "Adet";
            dashboardGraphHandler.SetLineChartDataToProfit();
            int randomnum = new Random().Next(5000);
            ViewCount += randomnum;
            if (CategoryTag == null)
            {
                PieChartSeries = dashboardGraphHandler.SetPieChartDataByCategories();
            }
            else
            {
                PieChartSeries = dashboardGraphHandler.SetPieChartDataByProducts(CategoryTag);
            }
        }
        public DashboardViewModel(MainViewModel mainViewModel)
        {
            ViewCount = new Random().Next(25000, 75000);
            UpdateDashboard();
            DispatcherTimer dispatcherTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 10) //h,m,s
            };
            dispatcherTimer.Tick += new EventHandler((object sender, EventArgs e) =>
            {
                UpdateDashboard();
            });
            dispatcherTimer.Start();
        }
    }
}
