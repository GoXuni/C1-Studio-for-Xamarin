using System;
using System.Collections.Generic;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public class WeatherData
    {
        public string MonthName { get; set; }
        public double Temp { get; set; }
        public double Precipitation { get; set; }
    }

    public partial class MultipleAxesController : UIViewController
    {
        FlexChart chart;

        public MultipleAxesController() : base("MultipleAxesController", null)
        {
        }

        public MultipleAxesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            chart = new FlexChart();
            chart.ItemsSource = GetWeatherData();
            chart.LegendPosition = ChartPositionType.None;
            chart.BindingX = "MonthName";

            chart.AxisY.Min = 4;
            chart.AxisY.Max = 20;
            chart.AxisY.MajorUnit = 2;
            chart.AxisY.Title = "Precipitation (in)";
            chart.AxisY.AxisLine = false;
            chart.AxisY.MajorGrid = true;
            chart.AxisY.TitleStyle = new ChartStyle { Stroke = new UIColor(0.533f, 0.741f, 0.902f, 1.0f) };

            ChartAxis axisT = new ChartAxis { Position = ChartPositionType.Right, Min = 0, Max = 80, MajorUnit = 10, Title = "Avg. Temperature (F)", AxisLine = false, MajorGrid = false };
            axisT.TitleStyle = new ChartStyle { Stroke = new UIColor(0.984f, 0.698f, 0.345f, 1.0f) };

            chart.Series.Add(new ChartSeries() { SeriesName = "Precip", Binding = "Precipitation" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Avg. Temp", Binding = "Temp", AxisY = axisT, ChartType = ChartType.SplineSymbols });

            this.Add(chart);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            chart.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80,
                                     this.View.Frame.Width, this.View.Frame.Height - 80);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public static IEnumerable<WeatherData> GetWeatherData()
        {
            List<WeatherData> weatherData = new List<WeatherData>();
            string[] monthNames = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            double[] tempData = new double[] { 24, 30, 45, 58, 68, 75, 83, 80, 72, 62, 47, 32 };
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
}

