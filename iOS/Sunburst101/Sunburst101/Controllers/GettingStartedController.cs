using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace Sunburst101
{
    public partial class GettingStartedController : UIViewController
    {
        C1Sunburst sunburst;

		public GettingStartedController() : base("GettingStartedController", null)
        {
        }

		public GettingStartedController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			sunburst = new C1Sunburst();
			sunburst.Binding = "Value";
			sunburst.BindingName = "Year,Quarter,Month";
			sunburst.ToolTipContent = "{}{name}\n{y}";
			sunburst.DataLabel.Position = PieLabelPosition.Center;
			sunburst.DataLabel.Content = "{}{name}";
			sunburst.ItemsSource = new SunburstViewModel().FlatData;
            this.Add(sunburst);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            CGRect rect = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80,
                                     this.View.Frame.Width, this.View.Frame.Height - 80);

            sunburst.Frame = new CGRect(rect.X, rect.Y, rect.Width, rect.Height  - 10);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

