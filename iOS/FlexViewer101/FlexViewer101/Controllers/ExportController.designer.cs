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

namespace FlexViewer101
{
    [Register ("ExportController")]
    partial class ExportController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Viewer.FlexViewer Viewer { get; set; }

        [Action ("UIBarButtonItem3137_Activated")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIBarButtonItem3137_Activated ();

        void ReleaseDesignerOutlets ()
        {
            if (Viewer != null) {
                Viewer.Dispose ();
                Viewer = null;
            }
        }
    }
}