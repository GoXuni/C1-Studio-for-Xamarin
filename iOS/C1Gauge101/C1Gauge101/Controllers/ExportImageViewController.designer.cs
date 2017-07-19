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
    [Register ("ExportImageViewController")]
    partial class ExportImageViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Gauge.C1RadialGauge RadialGauge { get; set; }

        [Action ("DoSnapshot:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DoSnapshot (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (RadialGauge != null) {
                RadialGauge.Dispose ();
                RadialGauge = null;
            }
        }
    }
}