using C1.iOS.Grid;
using System;
using UIKit;

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

            Grid.HeadersVisibility = GridHeadersVisibility.Column;
            Grid.BackgroundColor = UIColor.White;
            Grid.RowBackgroundColor = UIColor.FromRGB(0xE5, 0xE6, 0xFA);
            Grid.RowTextColor = UIColor.Black;
            Grid.AlternatingRowBackgroundColor = UIColor.White;
            Grid.GridLinesVisibility = GridLinesVisibility.Vertical;
            Grid.ColumnHeaderBackgroundColor = UIColor.FromRGB(0x77, 0x88, 0x98);
            Grid.ColumnHeaderTextColor = UIColor.White;
            Grid.ColumnHeaderFont = UIFont.BoldSystemFontOfSize(UIFont.LabelFontSize);
            Grid.SelectionBackgroundColor = UIColor.FromRGB(0xFA, 0xD1, 0x27);
            Grid.SelectionTextColor = UIColor.Black;
            Grid.AutoGenerateColumns = false;
            Grid.AllowResizing = GridAllowResizing.None;
            Grid.Columns.Add(new GridColumn { Binding = "FirstName", Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "LastName", Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "LastOrderDate", Width = GridLength.Star, Format = "d" });
            Grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Width = GridLength.Star, Format = "N", HorizontalAlignment = UIControlContentHorizontalAlignment.Right });
            var data = Customer.GetCustomerList(100);
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