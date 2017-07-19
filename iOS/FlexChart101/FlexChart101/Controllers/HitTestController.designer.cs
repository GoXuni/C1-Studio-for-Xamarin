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
    [Register ("HitTestController")]
    partial class HitTestController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel chartElementLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel pointIndexLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel seriesLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel xyValuesLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (chartElementLabel != null) {
                chartElementLabel.Dispose ();
                chartElementLabel = null;
            }

            if (pointIndexLabel != null) {
                pointIndexLabel.Dispose ();
                pointIndexLabel = null;
            }

            if (seriesLabel != null) {
                seriesLabel.Dispose ();
                seriesLabel = null;
            }

            if (xyValuesLabel != null) {
                xyValuesLabel.Dispose ();
                xyValuesLabel = null;
            }
        }
    }
}