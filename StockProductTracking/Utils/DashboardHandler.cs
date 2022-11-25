using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using LiveCharts;
using LiveCharts.Wpf;
using StockProductTracking.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockProductTracking.Utils
{
    internal class DashboardHandler
    {
        public ChartValues<Double> ChartValues = new ChartValues<Double>();

        public void SetChartDataToProfit()
        {
            ChartValues.Clear();
            ChartValues.Add(0);

            foreach (Order order in new Connect().GetAcceptedOrders())
            {
                ChartValues.Add(ChartValues.Last() + (order.OrderProductCount * order.OrderProductPrice));
            }
        } 
    }
}
