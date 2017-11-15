using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace Sunburst101
{
    public partial class SelectionController : UIViewController
    {
        private float mOffsetValue = 0.2f;

        public SelectionController() : base("SelectionController", null)
        {
        }

        public SelectionController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            sunburst.Binding = "Value";
            sunburst.BindingName = "Year,Quarter,Month";
            sunburst.DataLabel.Position = PieLabelPosition.Center;
            sunburst.DataLabel.Content = "{}{name}";
            sunburst.ItemsSource = new SunburstViewModel().FlatData;

            sunburst.SelectionMode = ChartSelectionModeType.Point;
            sunburst.ShowTooltip = false;
            offsetLabel.Text = mOffsetValue.ToString();
            sunburst.SelectedItemOffset = mOffsetValue;
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void positionChanged(UISegmentedControl sender)
        {
            sunburst.SelectedItemPosition = (ChartPositionType)(int)sender.SelectedSegment;
        }

        partial void stepperClicked(UIStepper sender)
        {
			offsetLabel.Text = sender.Value.ToString();
			sunburst.SelectedItemOffset = sender.Value;
        }
    }
}

