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
    [Register ("EditingFormController")]
    partial class EditingFormController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FirstNameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LastNameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LastOrderField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField OrderTotalField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem SaveButton { get; set; }

        [Action ("SaveButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveButton_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (FirstNameField != null) {
                FirstNameField.Dispose ();
                FirstNameField = null;
            }

            if (LastNameField != null) {
                LastNameField.Dispose ();
                LastNameField = null;
            }

            if (LastOrderField != null) {
                LastOrderField.Dispose ();
                LastOrderField = null;
            }

            if (OrderTotalField != null) {
                OrderTotalField.Dispose ();
                OrderTotalField = null;
            }

            if (SaveButton != null) {
                SaveButton.Dispose ();
                SaveButton = null;
            }
        }
    }
}