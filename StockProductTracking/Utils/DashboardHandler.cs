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
        public List<String> _YAxisIntervalList = new List<String>();
        public GraphAxis _YAxis;
        public GraphAxis _XAxis;

        public void SetChartDataToProfit()
        {
            ChartValues.Clear();
            ChartValues.Add(0);

            foreach (Order order in new Connect().GetAcceptedOrders())
            {
                ChartValues.Add(ChartValues.Last() + (order.OrderProductCount * order.OrderProductPrice));
            }

            _YAxis = new GraphAxis(Math.Ceiling((ChartValues.Max() / 3000)) * 3000);
            _XAxis = new GraphAxis(Convert.ToDouble(new Connect().GetTotalOrderCount()));
            
        }
    }

    internal class GraphAxis
    {
        private double _MaxValue;
        private double _MinValue;
        public double MaxValue { get => _MaxValue; set { _MaxValue = value; } }
        public double MinValue { get => _MinValue; set { _MinValue = value; } }

        public GraphAxis(double maxValue, double minValue = 0)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }
    }
}
