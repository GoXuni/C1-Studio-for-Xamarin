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
    [Register ("BulletGraphViewController")]
    partial class BulletGraphViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BadLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper BadStepper { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Gauge.C1BulletGraph BulletGraph { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GoodLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper GoodStepper { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TargetLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper TargetStepper { get; set; }

        [Action ("OnValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnValueChanged (UIKit.UIStepper sender);


        void ReleaseDesignerOutlets ()
        {
            if (BadLabel != null) {
                BadLabel.Dispose ();
                BadLabel = null;
            }

            if (BadStepper != null) {
                BadStepper.Dispose ();
                BadStepper = null;
            }

            if (BulletGraph != null) {
                BulletGraph.Dispose ();
                BulletGraph = null;
            }

            if (GoodLabel != null) {
                GoodLabel.Dispose ();
                GoodLabel = null;
            }

            if (GoodStepper != null) {
                GoodStepper.Dispose ();
                GoodStepper = null;
            }

            if (TargetLabel != null) {
                TargetLabel.Dispose ();
                TargetLabel = null;
            }

            if (TargetStepper != null) {
                TargetStepper.Dispose ();
                TargetStepper = null;
            }
        }
    }
}