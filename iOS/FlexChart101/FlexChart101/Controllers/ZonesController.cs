using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class ZonesController : UIViewController
    {
        FlexChart chart;

        public ZonesController() : base("ZonesController", null)
        {
        }

        public ZonesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            chart = new FlexChart();
            chart.BindingX = "Number";
            chart.ChartType = ChartType.Scatter;
            chart.AxisX.Title = "student number";
            chart.AxisY.Title = "student accumulated points";

            int nStudents = 20;
            int nMaxPoints = 100;
            IList<object> data = ZonesData.getZonesList(nStudents, nMaxPoints);
            chart.ItemsSource = data;
            this.Add(chart);

            double mean = this.FindMean(data);
            double stdDev = this.FindStdDev(data, mean);
            List<double> scores = new List<double>();
            foreach (ZonesData item in data)
            {
                scores.Add(item.Score);
            }
            scores.Sort((x, y) => y.CompareTo(x));

            var zones = new double[]
             {
                    scores[this.GetBoundingIndex(scores, 0.95)],
                    scores[this.GetBoundingIndex(scores, 0.75)],
                    scores[this.GetBoundingIndex(scores, 0.25)],
                    scores[this.GetBoundingIndex(scores, 0.05)]
             };

            NSArray colors = NSArray.FromObjects(UIColor.FromRGBA(0.99f, 0.75f, 0.75f, 1.00f),
                                                UIColor.FromRGBA(0.22f, 0.89f, 0.89f, 1.00f),
                                                UIColor.FromRGBA(1.00f, 0.89f, 0.50f, 1.00f),
                                                UIColor.FromRGBA(0.50f, 1.00f, 0.50f, 1.00f),
                                                UIColor.FromRGBA(0.50f, 0.50f, 1.00f, 1.00f));

            for (var i = 4; i >= 0; i--)
            {
                float y = (float)(i == 4 ? mean + 2 * stdDev : zones[i]);
                IList<object> sdata = new List<object>();
                for (int j = 0; j < data.Count; j++)
                {
                    sdata.Add(new ZonesData((double)j, (double)y));
                }

                string seriesName = ((char)((short)'A' + 4 - i)).ToString();
                ChartSeries series = new ChartSeries { SeriesName = seriesName, Binding = "Y" };
                series.ItemsSource = sdata;
                series.BindingX = "X";
                series.ChartType = ChartType.Area;
                series.Style = new ChartStyle { Fill = colors.GetItem<UIColor>((nuint)i) };
                chart.Series.Add(series);
            }
            chart.Series.Add(new ChartSeries { SeriesName = "raw score", Binding = "Score" });
            for (var i = -2; i <= 2; i++)
            {
                var y = mean + i * stdDev;
                string seriesName = string.Empty;
                if (i > 0)
                {
                    seriesName = "m+" + i + "s";
                }
                else if (i < 0)
                {
                    seriesName = "m" + i + "s";
                }
                else
                {
                    seriesName = "mean";
                }
                IList<object> sdata = new List<object>();
                for (int j = 0; j < data.Count; j++)
                {
                    sdata.Add(new ZonesData((double)j, (double)y));
                }
                ChartSeries series = new ChartSeries { SeriesName = seriesName, Binding = "Y" };
                series.ItemsSource = sdata;
                series.BindingX = "X";
                series.ChartType = ChartType.Line;
                series.Style = new ChartStyle { Fill = UIColor.Black, StrokeThickness = 2 };
                chart.Series.Add(series);
            }
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


        private double FindMean(IList<object> data)
        {
            double sum = 0;
            foreach (ZonesData item in data)
            {
                sum += item.Score;
            }
            return sum / data.Count;
        }
        private double FindStdDev(IList<object> data, double mean)
        {
            double sum = 0;
            for (var i = 0; i < data.Count; i++)
            {
                ZonesData item = (ZonesData)data[i];
                var d = item.Score - mean;
                sum += d * d;
            }
            return System.Math.Sqrt(sum / data.Count);
        }
        private int GetBoundingIndex(List<double> scores, double frac)
        {
            var n = scores.Count;
            int i = (int)System.Math.Ceiling(n * frac);
            while (i > scores[0] && scores[i] == scores[i + 1])
                i--;
            return i;
        }
    }

    public class ZonesData
    {
        public int Number { get; set; }
        public double Score { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public ZonesData(int Number, double Score)
        {
            this.Number = Number;
            this.Score = Score;
        }

        public ZonesData(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        // a method to create a list of zones sample objects of type ChartPoint
        public static IList<object> getZonesList(int nStudents, int nMaxPoints)
        {
            List<object> list = new List<object>();

            Random random = new Random();
            for (int i = 0; i < nStudents; i++)
            {
                ZonesData point = new ZonesData(i, nMaxPoints * 0.5 * (1 + random.NextDouble()));
                list.Add(point);
            }
            return list;
        }
    }
}

