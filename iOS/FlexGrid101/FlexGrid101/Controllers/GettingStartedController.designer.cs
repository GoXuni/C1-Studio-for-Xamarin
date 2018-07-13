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
    [Register ("GettingStartedController")]
    partial class GettingStartedController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        C1.iOS.Grid.FlexGrid Grid { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Grid != null) {
                Grid.Dispose ();
                Grid = null;
            }
        }
    }
}