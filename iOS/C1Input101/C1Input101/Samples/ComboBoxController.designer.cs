// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace C1Input101
{
    [Register ("ComboBoxController")]
    partial class ComboBoxController
    {
        [Outlet]
        C1.iOS.Input.C1ComboBox ComboBoxEdit { get; set; }


        [Outlet]
        C1.iOS.Input.C1ComboBox ComboBoxNonEdit { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ComboBoxEdit != null) {
                ComboBoxEdit.Dispose ();
                ComboBoxEdit = null;
            }

            if (ComboBoxNonEdit != null) {
                ComboBoxNonEdit.Dispose ();
                ComboBoxNonEdit = null;
            }
        }
    }
}