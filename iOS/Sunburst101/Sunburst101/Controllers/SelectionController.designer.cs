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
	[Register ("SelectionController")]
	partial class SelectionController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UILabel offsetLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UISegmentedControl positionSelector { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIStepper stepper { get; set; }

		[Outlet]
		C1.iOS.Chart.C1Sunburst sunburst { get; set; }

		[Action ("positionChanged:")]
		partial void positionChanged (UIKit.UISegmentedControl sender);

		[Action ("stepperClicked:")]
		partial void stepperClicked (UIKit.UIStepper sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (offsetLabel != null) {
				offsetLabel.Dispose ();
				offsetLabel = null;
			}

			if (positionSelector != null) {
				positionSelector.Dispose ();
				positionSelector = null;
			}

			if (sunburst != null) {
				sunburst.Dispose ();
				sunburst = null;
			}

			if (stepper != null) {
				stepper.Dispose ();
				stepper = null;
			}
		}
	}
}
