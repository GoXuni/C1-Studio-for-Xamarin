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

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField acmField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AutoCompleteMode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch clearSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ShowClearButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (acmField != null) {
                acmField.Dispose ();
                acmField = null;
            }

            if (AutoCompleteMode != null) {
                AutoCompleteMode.Dispose ();
                AutoCompleteMode = null;
            }

            if (clearSwitch != null) {
                clearSwitch.Dispose ();
                clearSwitch = null;
            }

            if (CustomDropdown != null) {
                CustomDropdown.Dispose ();
                CustomDropdown = null;
            }

            if (FilterDropdown != null) {
                FilterDropdown.Dispose ();
                FilterDropdown = null;
            }

            if (HighlightDropdown != null) {
                HighlightDropdown.Dispose ();
                HighlightDropdown = null;
            }

            if (ShowClearButton != null) {
                ShowClearButton.Dispose ();
                ShowClearButton = null;
            }
        }
    }
}