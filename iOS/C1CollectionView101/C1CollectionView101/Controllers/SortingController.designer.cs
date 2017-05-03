// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace C1CollectionView101
{
    [Register ("SortingController")]
    partial class SortingController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem SortButton { get; set; }

        [Action ("SortButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SortButton_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (SortButton != null) {
                SortButton.Dispose ();
                SortButton = null;
            }
        }
    }
}