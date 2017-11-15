using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using FlexChart101.DataModel;
using Android.Graphics;
using Java.Lang;
using C1.Android.Chart;
using C1.Android.Core;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/zones", Icon = "@drawable/icon")]
    public class ZonesActivity : AppCompatActivity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_zones);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.zones);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.zonesFlexchart);
            mChart.BindingX = "Number";
            mChart.ChartType = ChartType.Scatter;

            int nStudents = 20;
            int nMaxPoints = 100;
            IList<object> data = ZonesData.getZonesList(nStudents, nMaxPoints);
            mChart.ItemsSource = data;
            
            mChart.Tapped += MChart_Tapped;
            mChart.AxisX.Title = "student number";
            mChart.AxisY.Title = "student accumulated points";

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
                    scores[this.GetBoundingIndex(scores, 0.85)],
                    scores[this.GetBoundingIndex(scores, 0.75)],
                    scores[this.GetBoundingIndex(scores, 0.25)],
                    scores[this.GetBoundingIndex(scores, 0.05)]
             };

            Integer[] colors = new Integer[]
            {
                new Integer(Color.Argb(255,255,192,192)),
                new Integer(Color.Argb(255,55,228,228)),
                new Integer(Color.Argb(255,255,228,128)),
                new Integer(Color.Argb(255,128,255,128)),
                new Integer(Color.Argb(255,128,128,255)),
            };
            for (var i = 4; i >= 0; i--)
            {
                float y = (float)(i == 4 ? mean + 2 * stdDev : zones[i]);
                PointF[] sdata = new PointF[data.Count];

                for (int j = 0; j < data.Count; j++)
                {
                    sdata[j] = new PointF(j, y);
                    if (i == 0)
                    {
                        System.Console.WriteLine(j+"="+ y);
                    }
                }

                string seriesName = ((char)((short)'A' + 4 - i)).ToString();

                var series = new ChartSeries();
                series.Chart = mChart;
                series.SeriesName = seriesName;
                series.Binding = "Y";

                series.ItemsSource = sdata;
                series.BindingX = "X";
                series.ChartType = ChartType.Area;
                series.Style = new ChartStyle();
                series.Style.Fill = new Color(colors[i].IntValue());
                
                mChart.Series.Add(series);
            }

            ChartSeries scoreSeries = new ChartSeries();
            scoreSeries.Chart = mChart;
            scoreSeries.SeriesName = "raw score";
            scoreSeries.Binding = "Score";
            mChart.Series.Add(scoreSeries);

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
                PointF[] sdata = new PointF[data.Count];
                for (int j = 0; j < data.Count; j++)
                {
                    sdata[j] = new PointF(j, (float)y);
                }
                var series = new ChartSeries();
                series.Chart = mChart;
                series.SeriesName = seriesName;
                series.Binding = "Y";

                series.ItemsSource = sdata;
                series.BindingX = "X";
                series.ChartType = ChartType.Line;
                series.Style = new ChartStyle();
                series.Style.StrokeThickness = 2;

                series.Style.Stroke = Color.Rgb(0x20, 0x20, 0x20);

                mChart.Series.Add(series);
            }
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
        private void MChart_Tapped(object sender, C1TappedEventArgs e)
        {
            if (!mChart.ToolTip.Text.Contains("raw score"))
            {
                mChart.ToolTip.IsOpen = false;
            }

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}
