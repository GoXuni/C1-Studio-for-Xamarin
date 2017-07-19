// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace C1Input101
{
    [Register ("AutoCompleteController")]
    partial class AutoCompleteController
    {
        [Outlet]
        C1.iOS.Input.C1AutoComplete CustomDropdown { get; set; }


        [Outlet]
        C1.iOS.Input.C1AutoComplete DelayDropdown { get; set; }


        [Outlet]
        C1.iOS.Input.C1AutoComplete FilterDropdown { get; set; }


        [Outlet]
        C1.iOS.Input.C1AutoComplete HighlightDropdown { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CustomDropdown != null) {
                CustomDropdown.Dispose ();
                CustomDropdown = null;
            }

            if (DelayDropdown != null) {
                DelayDropdown.Dispose ();
                DelayDropdown = null;
            }

            if (FilterDropdown != null) {
                FilterDropdown.Dispose ();
                FilterDropdown = null;
            }

            if (HighlightDropdown != null) {
                HighlightDropdown.Dispose ();
                HighlightDropdown = null;
            }
        }
    }
}