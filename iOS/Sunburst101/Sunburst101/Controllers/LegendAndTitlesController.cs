using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;

namespace Sunburst101
{
    public partial class LegendAndTitlesController : UIViewController
    {

		public LegendAndTitlesController() : base("LegendAndTitlesController", null)
        {
        }

		public LegendAndTitlesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			sunburst.Binding = "Value";
            sunburst.BindingName = "Year,Quarter,Month";
			sunburst.ChildItemsPath = "Items";
            sunburst.ItemsSource = new SunburstViewModel().HierarchicalData;
            sunburst.LegendPosition = ChartPositionType.None;
            sunburst.ToolTipContent = "{}{name}\n{y}";
			headerField.Text = "Product By Value";
			footerField.Text = "2014 GrapeCity.inc.";
            sunburst.Header = headerField.Text;
			sunburst.Footer = footerField.Text;
           
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

		partial void changeLegendMode(UISegmentedControl sender)
		{
			sunburst.LegendPosition = (ChartPositionType)(int)sender.SelectedSegment;
		}

		partial void edited(UITextField sender)
		{
			sunburst.Header = headerField.Text;
			sunburst.Footer = footerField.Text;
		}

		partial void endEdit(UITextField sender)
		{
			sender.ResignFirstResponder();
		}
    }
}

