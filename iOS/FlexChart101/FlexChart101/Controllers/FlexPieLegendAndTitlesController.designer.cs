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
    [Register ("FlexPieLegendAndTitlesController")]
    partial class FlexPieLegendAndTitlesController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField footerField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField headerField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl legendModeSelector { get; set; }

        [Action ("changeLegendMode:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void changeLegendMode (UIKit.UISegmentedControl sender);

        [Action ("edited:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void edited (UIKit.UITextField sender);

        [Action ("endEdit:")]
        [GeneratedCode ("iOS Designer", "1.0")]
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
        }
    }
}