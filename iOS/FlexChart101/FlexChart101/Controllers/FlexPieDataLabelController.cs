using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class FlexPieDataLabelController : UIViewController
    {
        FlexPie pieChart;

        public FlexPieDataLabelController() : base("FlexPieDataLabelController", null)
        {
        }

        public FlexPieDataLabelController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            modeSelector.SelectedSegment = 1;

            pieChart = new FlexPie();
            pieChart.Binding = "Value";
            pieChart.BindingName = "Name";
            pieChart.ItemsSource = PieChartData.DemoData();
            pieChart.LegendPosition = ChartPositionType.Bottom;
            this.Add(pieChart);

            pieChart.DataLabel.Position = PieLabelPosition.Inside;
            pieChart.DataLabel.Content = "{y}";
            pieChart.DataLabel.Border = true;
            pieChart.DataLabel.BorderStyle = new ChartStyle { Stroke = UIColor.Red, StrokeThickness = 2 };
            pieChart.DataLabel.Style = new ChartStyle { FontFamily = UIFont.SystemFontOfSize(20, UIFontWeight.Black) };
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            pieChart.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80 + 30,
                                        this.View.Frame.Width, this.View.Frame.Height - 80 - 30);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void modeChanged(UISegmentedControl sender)
        {
            pieChart.DataLabel.Position = (PieLabelPosition)(int)sender.SelectedSegment;
        }

    }
}

