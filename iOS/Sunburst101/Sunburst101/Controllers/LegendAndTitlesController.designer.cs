// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Sunburst101
{
	[Register ("LegendAndTitlesController")]
	partial class LegendAndTitlesController
	{
		[Outlet]
		UIKit.UITextField footerField { get; set; }

		[Outlet]
		UIKit.UITextField headerField { get; set; }

		[Outlet]
		UIKit.UISegmentedControl legendModeSelector { get; set; }

		[Outlet]
		C1.iOS.Chart.C1Sunburst sunburst { get; set; }

		[Action ("changeLegendMode:")]
		partial void changeLegendMode (UIKit.UISegmentedControl sender);

		[Action ("edited:")]
		partial void edited (UIKit.UITextField sender);

		[Action ("endEdit:")]
		partial void endEdit (UIKit.UITextField sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (footerField != null) {
				footerField.Dispose ();
				footerField = null;
			}

			if (headerField != null) {
				headerField.Dispose ();
				headerField = null;
			}

			if (legendModeSelector != null) {
				legendModeSelector.Dispose ();
				legendModeSelector = null;
			}

			if (sunburst != null) {
				sunburst.Dispose ();
				sunburst = null;
			}
		}
	}
}
