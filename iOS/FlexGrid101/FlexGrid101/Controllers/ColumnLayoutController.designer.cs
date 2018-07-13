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
    [Register ("ColumnLayoutController")]
    partial class ColumnLayoutController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem EditButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Grid.FlexGrid Grid { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem SaveButton { get; set; }

        [Action ("SaveButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveButton_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (EditButton != null) {
                EditButton.Dispose ();
                EditButton = null;
            }

            if (Grid != null) {
                Grid.Dispose ();
                Grid = null;
            }

            if (SaveButton != null) {
                SaveButton.Dispose ();
                SaveButton = null;
            }
        }
    }
}