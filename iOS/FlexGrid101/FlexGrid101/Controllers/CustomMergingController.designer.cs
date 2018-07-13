// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace FlexGrid101
{
    [Register ("CustomMergingController")]
    partial class CustomMergingController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Grid.FlexGrid Grid { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ShowNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ShowTimeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Grid != null) {
                Grid.Dispose ();
                Grid = null;
            }

            if (ShowNameLabel != null) {
                ShowNameLabel.Dispose ();
                ShowNameLabel = null;
            }

            if (ShowTimeLabel != null) {
                ShowTimeLabel.Dispose ();
                ShowTimeLabel = null;
            }
        }
    }
}