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
    [Register ("AutoScaleViewController")]
    partial class AutoScaleViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Gauge.C1RadialGauge RadialGauge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StartAngleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper StartAngleStepper { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SweepAngleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper SweepAngleStepper { get; set; }

        [Action ("OnStepperValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnStepperValueChanged (UIKit.UIStepper sender);

        void ReleaseDesignerOutlets ()
        {
            if (RadialGauge != null) {
                RadialGauge.Dispose ();
                RadialGauge = null;
            }

            if (StartAngleLabel != null) {
                StartAngleLabel.Dispose ();
                StartAngleLabel = null;
            }

            if (StartAngleStepper != null) {
                StartAngleStepper.Dispose ();
                StartAngleStepper = null;
            }

            if (SweepAngleLabel != null) {
                SweepAngleLabel.Dispose ();
                SweepAngleLabel = null;
            }

            if (SweepAngleStepper != null) {
                SweepAngleStepper.Dispose ();
                SweepAngleStepper = null;
            }
        }
    }
}