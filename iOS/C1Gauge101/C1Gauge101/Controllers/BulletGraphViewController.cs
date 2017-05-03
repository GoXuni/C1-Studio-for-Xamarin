using Foundation;
using System;
using UIKit;

namespace C1Gauge101
{
    public partial class BulletGraphViewController : UIViewController
    {
        private const string GoodTextKey = "Good";
        private const string BadTextKey = "Bad";
        private const string TargetTextKey = "Target";
        private const string BulletGraphTitleKey = "BulletGraph";

        public BulletGraphViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = BulletGraphTitleKey.Localize();

            BadStepper.Value = BulletGraph.Bad;
            GoodStepper.Value = BulletGraph.Good;
            TargetStepper.Value = BulletGraph.Target;

            UpdateLabels();
        }

        partial void OnValueChanged(UIStepper sender)
        {
            var value = (int)sender.Value;

            if (sender == BadStepper)
            {
                BulletGraph.Bad = value;
            }
            else if (sender == GoodStepper)
            {
                BulletGraph.Good = value;
            }
            else if (sender == TargetStepper)
            {
                BulletGraph.Target = value;
            }

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            BadLabel.Text = string.Format("{0}: {1:D}", BadTextKey.Localize(), (int)BulletGraph.Bad);
            GoodLabel.Text = string.Format("{0}: {1:D}", GoodTextKey.Localize(), (int)BulletGraph.Good);
            TargetLabel.Text = string.Format("{0}: {1:D}", TargetTextKey.Localize(), (int)BulletGraph.Target);
        }
    }
}