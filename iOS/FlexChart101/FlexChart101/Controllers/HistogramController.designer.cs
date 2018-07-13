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
    [Register ("HistogramController")]
    partial class HistogramController
    {
        [Outlet]
        UIKit.UITextField textBox { get; set; }

        [Action ("edit:")]
        partial void edit (UIKit.UITextField sender);

        [Action ("endEdit:")]
        partial void endEdit (UIKit.UITextField sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (textBox != null) {
                textBox.Dispose ();
                textBox = null;
            }
        }
    }
}
