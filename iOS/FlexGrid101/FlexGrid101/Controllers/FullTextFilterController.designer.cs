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
    [Register ("FullTextFilterController")]
    partial class FullTextFilterController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Filter { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Grid.FlexGrid Grid { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Core.C1CheckBox MatchCaseCheckBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Core.C1CheckBox MatchWholeWordCheckBox { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Filter != null) {
                Filter.Dispose ();
                Filter = null;
            }

            if (Grid != null) {
                Grid.Dispose ();
                Grid = null;
            }

            if (MatchCaseCheckBox != null) {
                MatchCaseCheckBox.Dispose ();
                MatchCaseCheckBox = null;
            }

            if (MatchWholeWordCheckBox != null) {
                MatchWholeWordCheckBox.Dispose ();
                MatchWholeWordCheckBox = null;
            }
        }
    }
}