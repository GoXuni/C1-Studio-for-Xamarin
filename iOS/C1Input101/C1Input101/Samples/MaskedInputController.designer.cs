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
    [Register ("MaskedInputController")]
    partial class MaskedInputController
    {
        [Outlet]
        C1.iOS.Input.C1MaskedTextField MaskedDOB { get; set; }


        [Outlet]
        C1.iOS.Input.C1MaskedTextField MaskedID { get; set; }


        [Outlet]
        C1.iOS.Input.C1MaskedTextField MaskedPhone { get; set; }


        [Outlet]
        C1.iOS.Input.C1MaskedTextField MaskedState { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MaskedDOB != null) {
                MaskedDOB.Dispose ();
                MaskedDOB = null;
            }

            if (MaskedID != null) {
                MaskedID.Dispose ();
                MaskedID = null;
            }

            if (MaskedPhone != null) {
                MaskedPhone.Dispose ();
                MaskedPhone = null;
            }

            if (MaskedState != null) {
                MaskedState.Dispose ();
                MaskedState = null;
            }
        }
    }
}