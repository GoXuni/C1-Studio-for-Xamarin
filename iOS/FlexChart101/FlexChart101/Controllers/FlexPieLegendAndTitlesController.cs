using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class FlexPieLegendAndTitlesController : UIViewController
    {
        FlexPie pieChart;

        public FlexPieLegendAndTitlesController() : base("FlexPieLegendAndTitlesController", null)
        {
        }

        public FlexPieLegendAndTitlesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            legendModeSelector.SelectedSegment = 1;

            pieChart = new FlexPie();
            pieChart.Binding = "Value";
            pieChart.BindingName = "Name";
            pieChart.ItemsSource = PieChartData.DemoData();
            pieChart.LegendPosition = ChartPositionType.Right;
            pieChart.Header = headerField.Text;
            pieChart.HeaderStyle = new ChartStyle { Stroke = new UIColor(0.502f, 0.016f, 0.302f, 1), FontFamily = UIFont.SystemFontOfSize(24, UIFontWeight.Bold)};
            pieChart.Footer = footerField.Text;
            pieChart.FooterStyle = new ChartStyle { Stroke = new UIColor(0.502f, 0.016f, 0.302f, 1), FontFamily = UIFont.SystemFontOfSize(16, UIFontWeight.Bold) };

            this.Add(pieChart);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            pieChart.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80 + 60, 
                                        this.View.Frame.Width, this.View.Frame.Height - 80 - 60);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void changeLegendMode(UISegmentedControl sender)
        {
            pieChart.LegendPosition = (ChartPositionType)(int)sender.SelectedSegment;
        }

        partial void edited(UITextField sender)
        {
            pieChart.Header = headerField.Text;
            pieChart.Footer = footerField.Text;
        }

        partial void endEdit(UITextField sender)
        {
            sender.ResignFirstResponder();
        }
    }
}

