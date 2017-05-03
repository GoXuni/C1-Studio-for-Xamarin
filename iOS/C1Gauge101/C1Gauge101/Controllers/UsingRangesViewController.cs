using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using C1.iOS.Gauge;

namespace C1Gauge101
{
    public partial class UsingRangesViewController : UIViewController
    {
        private const double DefaultValue = 25;
        private const double DefaultMin = 0;
        private const double DefaultMax = 100;

        private const string UsingRangesTextKey = "UsingRanges";

        public UsingRangesViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = UsingRangesTextKey.Localize();

            LinearGauge.Min = RadialGauge.Min = Stepper.MinimumValue = DefaultMin;
            LinearGauge.Max = RadialGauge.Max = Stepper.MaximumValue = DefaultMax;
            LinearGauge.Value = RadialGauge.Value = Stepper.Value = DefaultValue;
            Stepper.StepValue = 25;

            LinearGauge.ValueChanged += OnValueChanged;
            RadialGauge.ValueChanged += OnValueChanged;

            IList<GaugeRange> ranges = new List<GaugeRange> {
                new GaugeRange { Min = 0, Max = 40, Color = UIColor.FromRGBA(0x22, 0xb1, 0x4c, 0xff) },
                new GaugeRange { Min = 40, Max = 80, Color = UIColor.FromRGBA(0xff, 0x80, 0x80, 0xff) },
                new GaugeRange { Min = 80, Max = 100, Color = UIColor.FromRGBA(0xee, 0xe0, 0x4a, 0xff) }
            };

            foreach (var range in ranges)
            {
                LinearGauge.Ranges.Add(range);
                RadialGauge.Ranges.Add(range);
            }

            Switch.On = false;
        }

        private void OnValueChanged(object sender, GaugeValueEventArgs e)
        {
            var value = e.Value;

            LinearGauge.Value = value;
            RadialGauge.Value = value;
            Stepper.Value = value;
        }

        partial void OnValueChanged(UIStepper sender)
        {
            var value = sender.Value;
            OnValueChanged(sender, new GaugeValueEventArgs(value));
        }

        partial void OnSwitchValueChanged(UISwitch sender)
        {
            LinearGauge.ShowRanges = !LinearGauge.ShowRanges;
            RadialGauge.ShowRanges = !RadialGauge.ShowRanges;
        }
    }
}