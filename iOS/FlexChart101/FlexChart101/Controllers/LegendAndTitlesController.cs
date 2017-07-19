using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class LegendAndTitlesController : UIViewController
    {
        FlexChart chart;

        public LegendAndTitlesController() : base("LegendAndTitlesController", null)
        {
        }

        public LegendAndTitlesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            chart = new FlexChart();
            chart.ChartType = C1.iOS.Chart.ChartType.Scatter;
            chart.BindingX = "Name";
            chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales,Sales" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses,Expenses" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Downloads", Binding = "Downloads,Downloads" });
            chart.ItemsSource = SalesData.GetSalesDataList();
            this.Add(chart);

            chart.Header = "Sample Chart";
            chart.HeaderAlignment = UITextAlignment.Center;
            chart.HeaderStyle = new ChartStyle { Stroke = new UIColor(0.502f, 0.016f, 0.302f, 1), FontFamily = UIFont.SystemFontOfSize(24, UIFontWeight.Bold)};
            chart.Footer = "2017 GrapeCity, Inc.";
            chart.FooterAlignment = UITextAlignment.Center;
            chart.FooterStyle = new ChartStyle { Stroke = new UIColor(0.502f, 0.016f, 0.302f, 1), FontFamily = UIFont.SystemFontOfSize(16, UIFontWeight.Bold) };

            chart.AxisX.Title = "Country";
            chart.AxisX.MajorGrid = true;
            chart.AxisX.TitleStyle = new ChartStyle { FontFamily = UIFont.ItalicSystemFontOfSize(16) };
            chart.AxisY.AxisLine = true;
            chart.AxisY.Labels = true;
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
    }
}

