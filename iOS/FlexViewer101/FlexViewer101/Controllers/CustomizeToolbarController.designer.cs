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

namespace FlexViewer101.Controllers
{
    [Register ("CustomizeToolbarController")]
    partial class CustomizeToolbarController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView StackLayout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Viewer.FlexViewer Viewer { get; set; }

        [Action ("UIBarButtonItem_OpenFile")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIBarButtonItem_OpenFile ();

        [Action ("UIBarButtonItem_Search")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIBarButtonItem_Search ();

        void ReleaseDesignerOutlets ()
        {
            if (StackLayout != null) {
                StackLayout.Dispose ();
                StackLayout = null;
            }

            if (Viewer != null) {
                Viewer.Dispose ();
                Viewer = null;
            }
        }
    }
}