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

namespace C1Calendar101
{
    [Register ("PopupEditorController")]
    partial class PopupEditorController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Message { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PickButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Message != null) {
                Message.Dispose ();
                Message = null;
            }

            if (PickButton != null) {
                PickButton.Dispose ();
                PickButton = null;
            }
        }
    }
}