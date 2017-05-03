using System;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class StarSizingController : UIViewController
    {
        public StarSizingController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Grid.AutoGenerateColumns = false;
            Grid.AllowResizing = GridAllowResizing.Columns;
            Grid.Columns.Add(new GridColumn { Binding = "FirstName", Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "LastName", Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "LastOrderDate", Width = GridLength.Star, Format = "d" });
            Grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Width = GridLength.Star, Format = "N", HorizontalAlignment = UIControlContentHorizontalAlignment.Right });
            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
        }
    }
}