using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;

namespace FlexChart101
{
    public static class PieChartSampleFactory
    {
        //public static FlexPie GetFlexChartSample(PieChartSample chartSample)
        //{
        //    switch (chartSample.PieChartSampleDataType)
        //    {
        //        case (int)PieChartSampleDataType.SALES_EXPENSES_DOWNLOADS:
        //            return SalesExpensesDownloads();
        //    }

        //    return null;
        //}

        public static IEnumerable<FruitEntity> CreateEntiyList()
        {
            List<FruitEntity> entityList = new List<FruitEntity>();

            string[] fruits = new string[] { "Oranges", "Apples", "Pears", "Bananas", "Pineapples" };

            Random random = new Random();

            for (int i = 0; i < fruits.Length; i++)
            {
                var value = random.Next(1, 10) * 100.12;

                entityList.Add(new FruitEntity(fruits[i], value));
            }
            return entityList;
        }

        private static FlexPie SalesExpensesDownloads()
        {
            FlexPie chart = new FlexPie();
            chart.BindingName = "Name";
            chart.Binding = "Value";
            chart.ItemsSource = CreateEntiyList();

            return chart;
        }
    }
}
