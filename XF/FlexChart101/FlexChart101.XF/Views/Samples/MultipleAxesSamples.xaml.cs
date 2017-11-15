using System;
using System.Collections.Generic;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class MultipleAxesSamples
    {
        public MultipleAxesSamples()
        {
            InitializeComponent();
            Title = AppResources.MultipleAxesTitle;

            this.flexChart.ItemsSource = GetWeatherData();
            this.flexChart.LegendPosition = ChartPositionType.None;
        }

        public IEnumerable<WeatherData> GetWeatherData()
        {
            List<WeatherData> weatherData = new List<WeatherData>();
            string[] monthNames = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            //double[] tempData = new double[] { 24, 30, 45, 58, 68, 75, 83, 80, 72, 62, 47, 32 };
            Random random = new Random();

            for (int i = 0; i < monthNames.Length; i++)
            {
                WeatherData wd = new WeatherData();
                wd.MonthName = monthNames[i];
                wd.Precipitation = random.Next(8, 18) + random.NextDouble();
                wd.Temp = Math.Tan(i * i) + 70;
                weatherData.Add(wd);
            }
            return weatherData;
        }
    }

    public class WeatherData
    {
        public string MonthName { get; set; }
        public double Temp { get; set; }
        public double Precipitation { get; set; }
    }
}
