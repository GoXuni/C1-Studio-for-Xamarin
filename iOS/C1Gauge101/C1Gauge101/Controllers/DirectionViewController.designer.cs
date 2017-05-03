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
    [Register ("DirectionViewController")]
    partial class DirectionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Gauge.C1BulletGraph BulletGraph { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Gauge.C1LinearGauge LinearGauge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView StackView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint StackViewHeightContraint { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UITextField Entry { get; set; }


        void ReleaseDesignerOutlets ()
        {
            if (BulletGraph != null) {
                BulletGraph.Dispose ();
                BulletGraph = null;
            }

            if (LinearGauge != null) {
                LinearGauge.Dispose ();
                LinearGauge = null;
            }

            if (StackView != null) {
                StackView.Dispose ();
                StackView = null;
            }

            if (StackViewHeightContraint != null) {
                StackViewHeightContraint.Dispose ();
                StackViewHeightContraint = null;
            }
        }
    }
}