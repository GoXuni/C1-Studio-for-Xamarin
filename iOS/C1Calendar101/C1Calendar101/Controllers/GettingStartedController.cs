using Foundation;
using System;
using UIKit;

namespace C1Calendar101
{
    public partial class GettingStartedController : UIViewController
    {
        public GettingStartedController (IntPtr handle) : base (handle)
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