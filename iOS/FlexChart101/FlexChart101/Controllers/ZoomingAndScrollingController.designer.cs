// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FlexChart101
{
	[Register ("ZoomingAndScrollingController")]
	partial class ZoomingAndScrollingController
	{
		[Outlet]
		C1.iOS.Chart.FlexChart chart { get; set; }

		[Outlet]
		UIKit.UISegmentedControl zoomModeSelector { get; set; }

		[Action ("zoomModeChanged:")]
		partial void zoomModeChanged (UIKit.UISegmentedControl sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (chart != null) {
				chart.Dispose ();
				chart = null;
			}

			if (zoomModeSelector != null) {
				zoomModeSelector.Dispose ();
				zoomModeSelector = null;
			}
		}
	}
}
