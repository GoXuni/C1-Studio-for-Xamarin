using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class FlexPieGettingStartedController : UIViewController
    {
        FlexPie pieChart;
        FlexPie donutChart;

        public FlexPieGettingStartedController() : base("FlexPieGettingStartedController", null)
        {
        }

        public FlexPieGettingStartedController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            pieChart = new FlexPie();
            pieChart.Binding = "Value";
            pieChart.BindingName = "Name";
            pieChart.ItemsSource = PieChartData.DemoData();
            this.Add(pieChart);

            donutChart = new FlexPie();
            donutChart.Binding = "Value";
            donutChart.BindingName = "Name";
            donutChart.ItemsSource = PieChartData.DemoData();
            donutChart.InnerRadius = 0.6;
            this.Add(donutChart);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            CGRect rect = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80,
                                     this.View.Frame.Width, this.View.Frame.Height - 80);

            pieChart.Frame = new CGRect(rect.X, rect.Y, rect.Width, rect.Height / 2 - 10);
            donutChart.Frame = new CGRect(rect.X, rect.Y + rect.Height / 2 + 20, rect.Width, rect.Height / 2 - 20);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

