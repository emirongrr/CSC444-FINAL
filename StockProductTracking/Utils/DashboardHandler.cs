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
        private List<String> GetUniqueItems(ObservableCollection<Order> orders)
        {
            List<String> returnValue = new List<String>();
            foreach (Order order in orders)
            {
                if (!returnValue.Contains(order.OrderProductTitle))
                {
                    returnValue.Add(order.OrderProductTitle);
                }
            }
            return returnValue;
        }
        public SeriesCollection GetChartData()
        {
            SeriesCollection chartSeries = new SeriesCollection();

            ObservableCollection<Order> orders = new Connect().GetAcceptedOrders();
            List<String> UniqueProductNameList = GetUniqueItems(orders);
            
            foreach (String uniqueProductName in UniqueProductNameList)
            {
                ChartValues<Double> values = new ChartValues<Double>();
                LineSeries ls = new LineSeries
                {
                    Title = uniqueProductName,
                    Values = values
                };
                chartSeries.Add(ls);
                foreach (Order o in orders)
                {
                    if (!(o.OrderProductTitle == uniqueProductName))
                    {
                        continue;
                    }
                    values.Add(o.OrderProductPrice * o.OrderProductCount);
                }
            }
            return chartSeries;
        } 
    }
}
