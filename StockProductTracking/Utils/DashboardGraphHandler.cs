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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockProductTracking.Utils
{
    internal class DashboardGraphHandler
    {
        public ChartValues<Double> ChartValues = new ChartValues<Double>();
        public GraphAxis YAxis { get; set; }
        public GraphAxis XAxis { get; set; }

        public void SetLineChartDataToProfit()
        {
            ChartValues.Clear();
            ChartValues.Add(0);

            foreach (Order order in new Connect().GetAcceptedOrders())
            {
                ChartValues.Add(ChartValues.Last() + (order.OrderProductCount * order.OrderProductPrice));
            }

            YAxis = new GraphAxis(Math.Ceiling((ChartValues.Max() / 3000)) * 3000);
            XAxis = new GraphAxis(Convert.ToDouble(new Connect().GetTotalOrderCount()));

        }
        public SeriesCollection SetPieChartDataByCategories()
        {
            Dictionary<String, Double> TotalProfitByCategories = new Dictionary<String, Double>();
            TotalProfitByCategories= new Connect().GetPieChartKeyValueFromDatabase();
            
            SeriesCollection PieChartSeriesCollection = new SeriesCollection();
            foreach(KeyValuePair<string, double> pair in TotalProfitByCategories)
            {
                ChartValues<double> pieValue = new ChartValues<double>();
                pieValue.Add(pair.Value);

                PieSeries pieSeries = new PieSeries()
                {
                    Title = pair.Key,
                    Values = pieValue
                };
                PieChartSeriesCollection.Add(pieSeries);
            }
            return PieChartSeriesCollection;
        }
        public SeriesCollection SetPieChartDataByProducts(string categoryTitle)
        {
            Dictionary<string, double> sellAmountByProduct = new Connect().GetPieChartKeyValueFromDatabaseWithCategory(categoryTitle);
            SeriesCollection PieChartSeriesCollection = new SeriesCollection();
            foreach(KeyValuePair<string,double> pair in sellAmountByProduct)
            {
                ChartValues<double> pieValue = new ChartValues<double>();
                pieValue.Add(pair.Value);
                PieChartSeriesCollection.Add(new PieSeries()
                {
                    Title = pair.Key,
                    Values = pieValue
                });
            }
            return PieChartSeriesCollection;
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
