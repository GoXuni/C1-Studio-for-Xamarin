using C1.iOS.Grid;
using System;
using UIKit;

namespace FlexGrid101
{
    public partial class GettingStartedController : UIViewController
    {
        public GettingStartedController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Grid.AutoGeneratingColumn += (s, e) => { e.Column.MinWidth = 110; e.Column.Width = GridLength.Star; };
            Grid.ItemsSource = Customer.GetCustomerList(100);
            Grid.AllowDragging = GridAllowDragging.Both;
            Grid.AllowResizing = GridAllowResizing.Both;
            //Use together with AllowResizing and AllowDragging to avoid gesture conflicts in the edge of the screen.
            NavigationController.InteractivePopGestureRecognizer.Enabled = false;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }
}