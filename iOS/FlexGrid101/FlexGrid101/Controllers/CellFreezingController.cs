using System;
using C1.iOS.Grid;
using UIKit;

namespace FlexGrid101
{
    public partial class CellFreezingController : UIViewController
    {
        public CellFreezingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = Customer.GetCustomerList(100);
            Grid.AutoGenerateColumns = false;
            Grid.DefaultColumnWidth = GridLength.Star;
            Grid.MinColumnWidth = 110;
            Grid.Columns.Add(new GridColumn { Binding = "Name", Width = 100 });
            Grid.Columns.Add(new GridColumn { Binding = "City" });
            Grid.Columns.Add(new GridColumn { Binding = "Country", AllowMerging = true });
            Grid.Columns.Add(new GridColumn { Binding = "PostalCode" });
            Grid.Columns.Add(new GridColumn { Binding = "Email" });
            Grid.Columns.Add(new GridColumn { Binding = "LastOrderDate" });
            Grid.ItemsSource = data;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }
}