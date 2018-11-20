// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace C1Calendar101
{
    [Register ("CustomHeaderController")]
    partial class CustomHeaderController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Calendar.C1Calendar Calendar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HeaderLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TodayButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView ViewModePicker { get; set; }

        [Action ("TodayButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TodayButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Calendar != null) {
                Calendar.Dispose ();
                Calendar = null;
            }

            if (HeaderLabel != null) {
                HeaderLabel.Dispose ();
                HeaderLabel = null;
            }

            if (TodayButton != null) {
                TodayButton.Dispose ();
                TodayButton = null;
            }

            if (ViewModePicker != null) {
                ViewModePicker.Dispose ();
                ViewModePicker = null;
            }
        }
    }
}