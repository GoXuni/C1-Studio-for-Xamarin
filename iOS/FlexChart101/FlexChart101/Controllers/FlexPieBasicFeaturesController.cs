using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace FlexChart101
{
    public partial class FlexPieBasicFeaturesController : UIViewController
    {
        public FlexPieBasicFeaturesController() : base("FlexPieBasicFeaturesController", null)
        {
        }

        public FlexPieBasicFeaturesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            pieChart.Binding = "Value";
            pieChart.BindingName = "Name";
            pieChart.ItemsSource = PieChartData.DemoData();
            this.Add(pieChart);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void offsetChanged(UISlider sender)
        {
            pieChart.Offset = sender.Value;
        }

        partial void startAngleChanged(UISlider sender)
        {
            pieChart.StartAngle = sender.Value;
        }


        partial void switchValueChanged(UISwitch sender)
        {
            pieChart.Reversed = sender.On;
        }

        partial void valueChanged(UIStepper sender)
        {
            pieChart.InnerRadius = stepper.Value;
            innerRadiusLabel.Text = stepper.Value.ToString();
            innerRadiusLabel.SizeToFit();
        }
    }
}

