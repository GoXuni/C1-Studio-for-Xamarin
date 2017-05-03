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

namespace C1Gauge101
{
    [Register ("UsingRangesViewController")]
    partial class UsingRangesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Gauge.C1LinearGauge LinearGauge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Gauge.C1RadialGauge RadialGauge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper Stepper { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch Switch { get; set; }

        [Action ("OnSwitchValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnSwitchValueChanged (UIKit.UISwitch sender);

        [Action ("OnValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnValueChanged (UIKit.UIStepper sender);

        void ReleaseDesignerOutlets ()
        {
            if (LinearGauge != null) {
                LinearGauge.Dispose ();
                LinearGauge = null;
            }

            if (RadialGauge != null) {
                RadialGauge.Dispose ();
                RadialGauge = null;
            }

            if (Stepper != null) {
                Stepper.Dispose ();
                Stepper = null;
            }

            if (Switch != null) {
                Switch.Dispose ();
                Switch = null;
            }
        }
    }
}