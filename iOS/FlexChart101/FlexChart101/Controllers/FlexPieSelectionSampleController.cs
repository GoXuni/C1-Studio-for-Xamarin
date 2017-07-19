using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class FlexPieSelectionSampleController : UIViewController
    {
        FlexPie pieChart;

        public FlexPieSelectionSampleController() : base("FlexPieSelectionSampleController", null)
        {
        }

        public FlexPieSelectionSampleController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            positionSelector.SelectedSegment = 3;

            pieChart = new FlexPie();
            pieChart.Binding = "Value";
            pieChart.BindingName = "Name";
            pieChart.ItemsSource = PieChartData.DemoData();
            pieChart.LegendPosition = ChartPositionType.Bottom;
            pieChart.SelectionMode = C1.iOS.Chart.ChartSelectionModeType.Point;
            pieChart.SelectedItemOffset = stepper.Value;
            pieChart.SelectedItemPosition = ChartPositionType.Bottom;
            this.Add(pieChart);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            pieChart.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 200,
                                        this.View.Frame.Width, this.View.Frame.Height - 200);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void positionChanged(UISegmentedControl sender)
        {
            pieChart.SelectedItemPosition = (ChartPositionType)(int)sender.SelectedSegment;
        }

        partial void stepperClicked(UIStepper sender)
        {
            pieChart.SelectedItemOffset = stepper.Value;
            offsetLabel.Text = stepper.Value.ToString();
        }
    }
}

