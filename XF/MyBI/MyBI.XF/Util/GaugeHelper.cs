using System;
using System.Linq;
using Xamarin.Forms;

namespace MyBI
{
    public class GaugeHelper
    {
        private static GaugeHelper _instance;

        public static GaugeHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GaugeHelper();
                return _instance;
            }
        }

        public Point GetGoalRange(bool isUnit = true)
        {
            double averageValue = isUnit ? Model.Instance.DetailItemList.Average(i => ((DetailDataItem)i).SumUnits) : Model.Instance.DetailItemList.Average(i => ((DetailDataItem)i).SumRevenue);
            double stdValue = MathHelper.Instance.StdDev(isUnit);
            stdValue = Math.Round(stdValue / 2.0, MidpointRounding.AwayFromZero);
            Point range = new Point(averageValue - stdValue, averageValue + stdValue);
            return range;
        }
    }
}
