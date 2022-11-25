using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.Model
{
    internal class GraphAxis
    {
        private double _MaxValue;
        private double _MinValue;
        public double MaxValue { get => _MaxValue; set { _MaxValue = value; } }
        public double MinValue { get => _MinValue; set { _MinValue = value; } }

        public GraphAxis(double maxValue, double minValue = 0 )
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }
    }
}
