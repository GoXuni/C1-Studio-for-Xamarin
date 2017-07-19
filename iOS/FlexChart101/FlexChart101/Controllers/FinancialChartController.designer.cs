// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FlexChart101
{
    [Register ("FinancialChartController")]
    partial class FinancialChartController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl switcher { get; set; }

        [Action ("modeSwitched:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void modeSwitched (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (switcher != null) {
                switcher.Dispose ();
                switcher = null;
            }
        }
    }
}