using Foundation;
using System;
using UIKit;
using C1.iOS.Gauge;

namespace C1Gauge101
{
    public partial class GettingStartedViewController : UIViewController
    {
        private const double DefaultValue = 25;
        private const double DefaultMin = 0;
        private const double DefaultMax = 100;

        private const string ValueTextKey = "Value";
        private const string GettingStartedTextKey = "GettingStarted";

        public GettingStartedViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavigationItem.Title = GettingStartedTextKey.Localize();

            LinearGauge.Min = BulletGraph.Min = RadialGauge.Min = Stepper.MinimumValue = DefaultMin;
            LinearGauge.Max = BulletGraph.Max = RadialGauge.Max = Stepper.MaximumValue = DefaultMax;
            LinearGauge.Value = BulletGraph.Value = RadialGauge.Value = Stepper.Value = DefaultValue;

            LinearGauge.ValueChanged += OnValueChanged;
            BulletGraph.ValueChanged += OnValueChanged;
            RadialGauge.ValueChanged += OnValueChanged;

            ValueLabel.Text = string.Format("{0}: {1:D}", ValueTextKey.Localize(), (int)DefaultValue);
            LinearGauge.Value = DefaultValue;
        }

        private void OnValueChanged(object sender, GaugeValueEventArgs e)
        {
            var value = e.Value;

            LinearGauge.Value = value;
            BulletGraph.Value = value;
            RadialGauge.Value = value;
            Stepper.Value = value;

            ValueLabel.Text = string.Format("{0}: {1:D}", ValueTextKey.Localize(), (int)value);
        }

        partial void OnValueChanged(UIStepper sender)
        {
            var value = sender.Value;
            OnValueChanged(sender, new GaugeValueEventArgs(value));
        }
    }
}