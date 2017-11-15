using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using FlexChart101.Resources;

namespace FlexChart101
{
    public partial class ZonesSample
    {
        public ZonesSample()
        {
            InitializeComponent();
            Title = AppResources.ZonesTitle;
            this.Init();
        }
        void Init()
        {
            int nStudents = 20;
            int nMaxPoints = 100;
            var data = ChartSampleFactory.GetZonesData(nStudents, nMaxPoints).ToArray();
            this.flexChart.ItemsSource = data;
            double mean = this.FindMean(data);
            double stdDev = this.FindStdDev(data, mean);
            List<double> scores = new List<double>();
            foreach (var item in data)
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

            var colors = new Color[]
            {
                Color.FromRgba(255,192,192,255),
                Color.FromRgba(55,228,228,255),
                Color.FromRgba(255,228,128,255),
                Color.FromRgba(128,255,128,255),
                Color.FromRgba(128,128,255,255),
            };
            for (var i = 4; i >= 0; i--)
            {
                double y = i == 4 ? mean + 2 * stdDev : zones[i];
                Point[] sdata = new Point[data.Length];

                for (int j = 0; j < data.Length; j++)
                {
                    sdata[j] = new Point(j, y);
                }
                var series = new ChartSeries();
                series.ItemsSource = sdata;
                series.Binding = "Y";
                series.BindingX = "X";
                series.ChartType = ChartType.Area;
                //series.Color = colors[ i];
                series.SeriesName = ((char)((short)'A' + 4 - i)).ToString();
                this.flexChart.Series.Add(series);
            }

            this.flexChart.Series.Add(new ChartSeries() { Chart = this.flexChart, SeriesName = "raw score", Binding = "Score" });

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
                Point[] sdata = new Point[data.Length];
                for (int j = 0; j < data.Length; j++)
                {
                    sdata[j] = new Point(j, y);
                }

                var series = new ChartSeries() { Chart = this.flexChart, SeriesName = seriesName, Binding = "Y" };
                series.ItemsSource = sdata;
                series.BindingX = "X";
                series.ChartType = ChartType.Line;
                series.Style = new ChartStyle { StrokeThickness = 2 };
                if (Device.OS == TargetPlatform.WinPhone)
                    series.Style.Stroke = Color.Blue;
                else
                    series.Style.Stroke = Color.FromRgb(0x20, 0x20, 0x20);

                this.flexChart.Series.Add(series);
            }
        }



        private double FindMean(ZonesData[] data)
        {
            double sum = 0;
            foreach (var item in data)
            {
                sum += item.Score;
            }
            return sum / data.Length;
        }
        private double FindStdDev(ZonesData[] data, double mean)
        {
            double sum = 0;
            for (var i = 0; i < data.Length; i++)
            {
                var d = data[i].Score - mean;
                sum += d * d;
            }
            return Math.Sqrt(sum / data.Length);
        }
        private int GetBoundingIndex(List<double> scores, double frac)
        {
            var n = scores.Count;
            int i = (int)Math.Ceiling(n * frac);
            while (i > scores[0] && scores[i] == scores[i + 1])
                i--;
            return i;
        }
    }
}

