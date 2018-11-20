using System;
using System.Linq;

namespace MyBI
{
    public class MathHelper
    {
        private static MathHelper _instance;

        public static MathHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MathHelper();
                return _instance;
            }
        }

        public double StdDev(bool isUnit = true)
        {
            double result = 0;
            int count = Model.Instance.DetailItemList.Count();
            if (count > 1)
            {
                double averageValue = isUnit ? Model.Instance.ItemList.Average(i => ((DataItem)i).Units) : Model.Instance.ItemList.Average(i => ((DataItem)i).Revenue);
                averageValue = Math.Round(averageValue, MidpointRounding.AwayFromZero);
                double sumValue = isUnit ? Model.Instance.ItemList.Sum(i => (((DataItem)i).Units - averageValue) * (((DataItem)i).Units - averageValue)) : Model.Instance.ItemList.Sum(i => (((DataItem)i).Revenue - averageValue) * (((DataItem)i).Revenue - averageValue));
                result = Math.Sqrt(sumValue / count);
            }
            return result;
        }

        public double RoundDouble(double value, int count)
        {
            string tempValue = value.ToString();
            if (count == tempValue.Length)
                return value;
            else
            {
                char[] valueArray = tempValue.ToCharArray();
                for (int i = 0; i < tempValue.Length; i++)
                {
                    if (i > count - 1)
                        valueArray[i] = '0';
                }
                tempValue = new string(valueArray);
                return double.Parse(tempValue);
            }
        }

        public double GetMaxValue(bool isUnit = true)
        {
            double maxValue = isUnit ? Model.Instance.DetailItemList.Max(i => ((DetailDataItem)i).SumUnits) : Model.Instance.DetailItemList.Max(i => ((DetailDataItem)i).SumRevenue);
            maxValue = Math.Round(maxValue, MidpointRounding.AwayFromZero);
            maxValue = AddOneForIndex(maxValue, 1);
            maxValue = RoundForIndex(maxValue, 1);
            return maxValue;
        }

        private double AddOneForIndex(double value, int index)
        {
            string tempValue = value.ToString();
            if (index > tempValue.Length)
                return value;
            else
            {
                int count = tempValue.Length - index;
                string addValue = "1";
                for (int i = 0; i < count - 1; i++)
                    addValue += "0";
                value += double.Parse(addValue);
                return value;
            }
        }

        private double RoundForIndex(double value, int index)
        {
            string tempValue = value.ToString();
            if (index == tempValue.Length)
                return value;
            else
            {
                char[] valueArray = tempValue.ToCharArray();
                for (int i = 0; i < tempValue.Length; i++)
                {
                    if (i > index)
                        valueArray[i] = '0';
                }
                tempValue = new string(valueArray);
                return double.Parse(tempValue);
            }
        }
    }
}
