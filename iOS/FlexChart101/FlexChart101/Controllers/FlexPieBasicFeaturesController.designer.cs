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
    [Register ("FlexPieBasicFeaturesController")]
    partial class FlexPieBasicFeaturesController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel innerRadiusLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider offsetSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch reversedSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider startAngleSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper stepper { get; set; }

        [Action ("offsetChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void offsetChanged (UIKit.UISlider sender);

        [Action ("startAngleChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void startAngleChanged (UIKit.UISlider sender);

        [Action ("switchValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void switchValueChanged (UIKit.UISwitch sender);

        [Action ("valueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void valueChanged (UIKit.UIStepper sender);

        void ReleaseDesignerOutlets ()
        {
            if (innerRadiusLabel != null) {
                innerRadiusLabel.Dispose ();
                innerRadiusLabel = null;
            }

            if (offsetSlider != null) {
                offsetSlider.Dispose ();
                offsetSlider = null;
            }

            if (reversedSwitch != null) {
                reversedSwitch.Dispose ();
                reversedSwitch = null;
            }

            if (startAngleSlider != null) {
                startAngleSlider.Dispose ();
                startAngleSlider = null;
            }

            if (stepper != null) {
                stepper.Dispose ();
                stepper = null;
            }
        }
    }
}