using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class DynamicChartsController : UIViewController
    {
        FlexChart chart;
        List<DummyObject> list = new List<DummyObject>();
        Random random = new Random();

        public DynamicChartsController() : base("DynamicChartsController", null)
        {
        }

        public DynamicChartsController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            for (int i = 0; i < 30; i++)
            {
                list.Add(getItem());
            }



            chart = new FlexChart();
            chart.BindingX = "Name";
            chart.Series.Add(new ChartSeries() { SeriesName = "Trucks", Binding = "Trucks,Trucks" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Ships", Binding = "Ships,Ships" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Planes", Binding = "Planes,Planes" });
            chart.ItemsSource = list;
            chart.Palette = Palette.Coral;
            chart.ToolTip = null;
            chart.ChartType = ChartType.Line;
            this.Add(chart);

            InvokeInBackground(() =>
            {
                bool flag = true;
                while (flag)
                {
                    NSThread.SleepFor(.15);
                    InvokeOnMainThread(() =>
                    {
                        if (list.Count > 30)
                            list.RemoveAt(0);
                        list.Add(getItem());
                        chart.ItemsSource = list.ToArray();

                        if (!IsViewLoaded)
                            flag = false;
                    });
                }
            });
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


        public DummyObject getItem()
        {
            double nextDouble = random.Next(0, 1000);

            while (nextDouble < 900)
            {
                nextDouble = random.Next(0, 1000);
            }

            double trucks = nextDouble + 20;
            double ships = nextDouble + 10;
            double planes = nextDouble;

            DateTime now = DateTime.Now;

            return new DummyObject(now, now.ToString("mm:ss"), trucks, ships, planes);
        }

        public class DummyObject
        {
            public String Name { get; set; }

            public DateTime Time { get; set; }

            public double Trucks { get; set; }

            public double Ships { get; set; }

            public double Planes { get; set; }

            public DummyObject(DateTime time, String name, double trucks, double ships, double planes)
            {
                this.Time = time;
                this.Name = name;
                this.Trucks = trucks;
                this.Ships = ships;
                this.Planes = planes;
            }

        }
    }
}

