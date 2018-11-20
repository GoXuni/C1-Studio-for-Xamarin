using System;

namespace MyBI
{
    public class DetailDataItem
    {
        public DateTime Month { get; set; }
        public double SumRevenue { get; set; }
        public double SumUnits { get; set; }
        public double MaxUnits { get; set; }
        public double MaxRevenue { get; set; }
        public double TrendUnitValue { get; set; }
        public double TrendRevenueValue { get; set; }
    }
}
