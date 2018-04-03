// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FlexChart101.Controllers
{
    [Register ("PieAnimationController")]
    partial class PieAnimationController
    {
        [Outlet]
        C1.iOS.Chart.FlexPie flexPie { get; set; }

        [Outlet]
        UIKit.UILabel innerRadiusLabel { get; set; }

        [Outlet]
        UIKit.UIPickerView picker { get; set; }

        [Outlet]
        UIKit.UIStepper stepper { get; set; }

        [Outlet]
        UIKit.UISegmentedControl yearSelector { get; set; }

        [Action ("valueChanged:")]
        partial void valueChanged (UIKit.UIStepper sender);

        [Action ("yearChanged:")]
        partial void yearChanged (UIKit.UISegmentedControl sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (flexPie != null) {
                flexPie.Dispose ();
                flexPie = null;
            }

            if (yearSelector != null) {
                yearSelector.Dispose ();
                yearSelector = null;
            }

            if (picker != null) {
                picker.Dispose ();
                picker = null;
            }

            if (stepper != null) {
                stepper.Dispose ();
                stepper = null;
            }

            if (innerRadiusLabel != null) {
                innerRadiusLabel.Dispose ();
                innerRadiusLabel = null;
            }
        }
    }
}
