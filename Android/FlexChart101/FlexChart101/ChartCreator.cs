using System;
using System.Collections.Generic;

using Android.Views;
using C1.Android.Chart;

namespace FlexChart101
{
    public class Chartinitialization
    {
        public static void InitialDefaultChart(FlexChart flexChart,IList<object> itemsSource)
        {
            ChartSeries seriesSales = new ChartSeries();
            seriesSales.Chart = flexChart;
            seriesSales.SeriesName = "Sales";
            seriesSales.Binding = "Sales";

            ChartSeries seriesExpenses = new ChartSeries();
            seriesExpenses.Chart = flexChart;
            seriesExpenses.SeriesName = "Expenses";
            seriesExpenses.Binding = "Expenses";

            ChartSeries seriesDownloads = new ChartSeries();
            seriesDownloads.Chart = flexChart;
            seriesDownloads.SeriesName = "Downloads";
            seriesDownloads.Binding = "Downloads";

            flexChart.BindingX = "Name";
            // add series to list
            flexChart.Series.Add(seriesSales);
            flexChart.Series.Add(seriesExpenses);
            flexChart.Series.Add(seriesDownloads);

            flexChart.ItemsSource = itemsSource;

            flexChart.AxisX.MajorGridStyle.FontSize = 0;
            flexChart.AxisX.MinorGridStyle.FontSize = 1;
        }
    }
}