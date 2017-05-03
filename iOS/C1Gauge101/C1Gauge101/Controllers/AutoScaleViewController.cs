using Foundation;
using System;
using UIKit;

namespace C1Gauge101
{
    public partial class AutoScaleViewController : UIViewController
    {
        private const string AutoScaleTitleKey = "AutoScale";

        public AutoScaleViewController (IntPtr handle) : base (handle)
        {
        }

        private const string StartAngleTextKey = "StartAngle";
        private const string SweepAngleTextKey = "SweepAngle";

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = AutoScaleTitleKey.Localize();

            UpdateText();
        }

        partial void OnStepperValueChanged(UIStepper sender)
        {
            if (sender == StartAngleStepper)
            {
                RadialGauge.StartAngle = StartAngleStepper.Value;
            }
            else if (sender == SweepAngleStepper)
            {
                RadialGauge.SweepAngle = SweepAngleStepper.Value;
            }

            UpdateText();
        }

        private void UpdateText()
        {
            StartAngleLabel.Text = string.Format("{0}: {1:D}", StartAngleTextKey.Localize(), (int)StartAngleStepper.Value);
            SweepAngleLabel.Text = string.Format("{0}: {1:D}", SweepAngleTextKey.Localize(), (int)SweepAngleStepper.Value);
        }
    }
}