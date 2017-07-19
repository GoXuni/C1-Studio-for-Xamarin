using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class FinancialChartController : UIViewController
    {
        FlexChart chart;

        public FinancialChartController() : base("FinancialChartController", null)
        {
        }

        public FinancialChartController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            chart = new FlexChart();
            chart.BindingX = "Date";
            chart.Series.Add(new ChartSeries() { SeriesName = "AAPL", Binding = "High,Low,Open,Close" });
            chart.ItemsSource = FinancialData.GetFinancialDataList();
            chart.ChartType = ChartType.Candlestick;
            chart.SelectionMode = ChartSelectionModeType.Point;
            chart.LegendPosition = ChartPositionType.None;
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

        partial void modeSwitched(UISegmentedControl sender)
        {
            switch (sender.SelectedSegment)
            {
                case 0:
                    chart.ChartType = ChartType.Candlestick;
                    break;
                case 1:
                    chart.ChartType = ChartType.HighLowOpenClose;
                    break;
            }

        }
    }
}

