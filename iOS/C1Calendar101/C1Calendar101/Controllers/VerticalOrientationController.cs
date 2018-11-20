using Foundation;
using System;
using UIKit;

namespace C1Calendar101
{
    public partial class VerticalOrientationController : UIViewController
    {
        public VerticalOrientationController (IntPtr handle) : base (handle)
        {
        }
        public override void DidReceiveMemoryWarning()
        {
            Calendar.RemoveFromSuperview();
            ReleaseDesignerOutlets();
            base.DidReceiveMemoryWarning();
        }
    }
}