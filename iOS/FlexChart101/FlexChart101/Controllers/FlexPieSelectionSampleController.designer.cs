// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FlexChart101
{
    [Register ("FlexPieSelectionSampleController")]
    partial class FlexPieSelectionSampleController
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

        [Action ("positionChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void positionChanged (UIKit.UISegmentedControl sender);

        [Action ("stepperClicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
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

            if (stepper != null) {
                stepper.Dispose ();
                stepper = null;
            }
        }
    }
}