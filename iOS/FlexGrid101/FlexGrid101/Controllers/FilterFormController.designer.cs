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
    [Register ("FilterFormController")]
    partial class FilterFormController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem DoneButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Grid.FlexGrid Grid { get; set; }

        [Action ("DoneButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DoneButton_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (DoneButton != null) {
                DoneButton.Dispose ();
                DoneButton = null;
            }

            if (Grid != null) {
                Grid.Dispose ();
                Grid = null;
            }
        }
    }
}