using System;
using System.Linq;
using Xamarin.Forms;

namespace MyBI
{
    public class FlexChartHelper
    {
        private static FlexChartHelper _instance;

        public static FlexChartHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FlexChartHelper();
                return _instance;
            }
        }

        public bool IsUnitTrendUp { get; private set; }
        public bool IsRevenueTrendUp { get; private set; }

        public Point UnitStartPoint { get; private set; }
        public Point RevenueStartPoint { get; private set; }
        public Point UnitEndPoint { get; private set; }
        public Point RevenueEndPoint { get; private set; }

        public double GetFavourableAxisYValue(double rowCount, bool isUnit = true)
        {
            double maxValue = isUnit ? Model.Instance.DetailItemList.Max(i => ((DetailDataItem)i).SumUnits) : Model.Instance.DetailItemList.Max(i => ((DetailDataItem)i).SumRevenue);
            double majorUnit = Math.Round(maxValue / rowCount, MidpointRounding.AwayFromZero);
            majorUnit = MathHelper.Instance.RoundDouble(majorUnit, 1);
            return majorUnit;
        }

        public double CalculateTrendLine(out double startValue, bool isUnit = true)
        {
            double fristValue = isUnit ? (Model.Instance.DetailItemList.First() as DetailDataItem).SumUnits : (Model.Instance.DetailItemList.First() as DetailDataItem).SumRevenue;
            double lastValue = isUnit ? (Model.Instance.DetailItemList.Last() as DetailDataItem).SumUnits : (Model.Instance.DetailItemList.Last() as DetailDataItem).SumRevenue;
            double averageValue = isUnit ? Model.Instance.DetailItemList.Average(i => ((DetailDataItem)i).SumUnits) : Model.Instance.DetailItemList.Average(i => ((DetailDataItem)i).SumRevenue);
            double trendPercent = (lastValue - fristValue) / fristValue;
            bool isUp = trendPercent > 0;
            if (isUnit)
                IsUnitTrendUp = isUp;
            else
                IsRevenueTrendUp = isUp;
            double nextValue = lastValue * (1 + trendPercent);
            startValue = isUp ? Math.Min(averageValue, fristValue) * (1 - trendPercent) : Math.Max(averageValue, fristValue) * (1 - trendPercent);
            double delta = (nextValue - startValue) / Model.Instance.DetailItemList.Count;
            return delta;
        }
    }
}
