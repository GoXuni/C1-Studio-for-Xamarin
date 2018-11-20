using System;
using UIKit;

namespace FlexGrid101
{
    public partial class CellFreezingController : UIViewController
    {
        public CellFreezingController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
            Grid.Columns["Country"].AllowMerging = true;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }
}