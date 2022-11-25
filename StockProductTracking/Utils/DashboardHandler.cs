using Google.Protobuf.WellKnownTypes;
using LiveCharts;
using LiveCharts.Wpf;
using StockProductTracking.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.Utils
{
    internal class DashboardHandler
    {
        public SeriesCollection GetChartData()
        {
            SeriesCollection chartSeries = new SeriesCollection();
            ChartValues<Double> values = new ChartValues<Double>();
            LineSeries ls = new LineSeries
            {
                Title = "Toplam Kar",
                Values = values
            };
            chartSeries.Add(ls);
            foreach (Order order in new Connect().GetAcceptedOrders())
            {
                if (values.Any())
                {
                    values.Add(values.Last() + (order.OrderProductCount * order.OrderProductPrice));
                }
                else
                {
                    values.Add(order.OrderProductPrice * order.OrderProductCount);
                } 
            }
            return chartSeries;
        } 
    }
}
