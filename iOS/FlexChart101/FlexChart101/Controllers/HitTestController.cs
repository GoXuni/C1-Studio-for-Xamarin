using System;
using System.Collections.Generic;

using UIKit;
using CoreGraphics;
using C1.iOS.Core;
using C1.iOS.Chart;
using Foundation;

namespace FlexChart101
{
    public partial class HitTestController : UIViewController
    {
        FlexChart chart;

        public HitTestController() : base("HitTestController", null)
        {
        }

        public HitTestController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            int len = 40;
            List<CGPoint> listCosTuple = new List<CGPoint>();
            List<CGPoint> listSinTuple = new List<CGPoint>();

            for (int i = 0; i < len; i++)
            {
                listCosTuple.Add(new CGPoint(i, Math.Cos(0.12 * i)));
                listSinTuple.Add(new CGPoint(i, Math.Sin(0.12 * i)));
            }

            chart = new FlexChart();
            chart.BindingX = "X";
            chart.ChartType = ChartType.LineSymbols;
            chart.AxisY.Format = "F";
            chart.Header = "Trigonometric Functions";
            chart.Footer = "Cartesian coordinates";

            chart.Series.Add(new ChartSeries() { SeriesName = "cos(x)", Binding = "Y,Y", ItemsSource = listCosTuple });
            chart.Series.Add(new ChartSeries() { SeriesName = "sin(x)", Binding = "Y,Y", ItemsSource = listSinTuple });

            chart.Tapped += OnChartTapped;
            this.Add(chart);
        }

        private void OnChartTapped(object sender, C1TappedEventArgs e)
        {
            var pt = e.GetPosition(chart);
            var info = chart.HitTest(pt);

            if (info != null)
            {
                pointIndexLabel.Text = string.Format(NSBundle.MainBundle.LocalizedString("Point Index", "Point Index") + "{0}", info.PointIndex);
                xyValuesLabel.Text = string.Format(NSBundle.MainBundle.LocalizedString("X Y Values", "X Y Values") + " X: {0}, Y: {1:F2}", info.X, info.Y);

                if (info.Series != null)
                {
                    seriesLabel.Text = string.Format(NSBundle.MainBundle.LocalizedString("SeriesName", "SeriesName") + "{0}", info.Series.Name);
                }
                else
                {
                    seriesLabel.Text = NSBundle.MainBundle.LocalizedString("SeriesName", "SeriesName");
                }
                chartElementLabel.Text = string.Format(NSBundle.MainBundle.LocalizedString("Chart element", " Chart element") + "{0}", info.ChartElement.ToString());
            }
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            chart.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80,
                                     this.View.Frame.Width, this.View.Frame.Height - 80 - 140);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

