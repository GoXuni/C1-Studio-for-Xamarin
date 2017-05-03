using System;
using UIKit;

namespace FlexGrid101
{
    public partial class GettingStartedController : UIViewController
    {
        public GettingStartedController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Grid.ItemsSource = Customer.GetCustomerList(100);
        }
    }
}