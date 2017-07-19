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
    [Register ("FlexPieDataLabelController")]
    partial class FlexPieDataLabelController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl modeSelector { get; set; }

        [Action ("modeChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void modeChanged (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (modeSelector != null) {
                modeSelector.Dispose ();
                modeSelector = null;
            }
        }
    }
}