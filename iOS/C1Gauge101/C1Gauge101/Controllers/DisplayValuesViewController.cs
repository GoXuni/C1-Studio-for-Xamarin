using Foundation;
using System;
using System.Linq;
using System.Collections.Generic;
using UIKit;

using C1.iOS.Gauge;
using C1.iOS.Core;

namespace C1Gauge101
{
    public partial class DisplayValuesViewController : UIViewController
    {
        private const double DefaultValue = 0.25;
        private const double DefaultMin = 0;
        private const double DefaultMax = 1;
        private const string DefaultFormat = "P0";

        private const string DisplayValueTextKey = "DisplayValue";

        private IList<string> showTextItems = new List<string>() {
            GaugeShowText.All.ToString(),
            GaugeShowText.Value.ToString(),
            GaugeShowText.MinMax.ToString(),
            GaugeShowText.None.ToString()
        };

        public IList<string> ShowTextItems
        {
            get
            {
                return showTextItems;
            }
        }

        public DisplayValuesViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = DisplayValueTextKey.Localize();
            const GaugeShowText ShowTextAll = GaugeShowText.All;

            LinearGauge.Min = RadialGauge.Min = Stepper.MinimumValue = DefaultMin;
            LinearGauge.Max = RadialGauge.Max = Stepper.MaximumValue = DefaultMax;
            LinearGauge.Value = RadialGauge.Value = Stepper.Value = DefaultValue;
            Stepper.StepValue = 0.25;
            LinearGauge.Format = RadialGauge.Format = DefaultFormat;
            LinearGauge.ShowText = ShowTextAll;
            RadialGauge.ShowText = ShowTextAll;

            LinearGauge.ValueChanged += OnValueChanged;
            RadialGauge.ValueChanged += OnValueChanged;

            var localizedItems = new List<string>();
            ShowTextItems.ToList().ForEach(x => localizedItems.Add(x.Localize()));

            Entry.ToPickerWithValues(localizedItems, (int)ShowTextAll, (selectedIndex) =>
            {
                var showText = (GaugeShowText)Enum.Parse(typeof(GaugeShowText), ShowTextItems[selectedIndex]);
                LinearGauge.ShowText = RadialGauge.ShowText = showText;
            });
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
    }
}