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
        public double MaxValue { get => _MaxValue; set { value = _MaxValue; } }
        public double MinValue { get => _MinValue; set { value = _MinValue; } }

        public GraphAxis(double minValue, double maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }
    }
}
