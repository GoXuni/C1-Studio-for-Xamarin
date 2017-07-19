using System;
using UIKit;
using C1.iOS.Grid;
using C1.iOS.Core;

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
            Grid.RowBackgroundColor = ColorEx.FromARGB(0xFF, 0xE5, 0xE6, 0xFA);
            Grid.RowTextColor = UIColor.Black;
            Grid.AlternatingRowBackgroundColor = UIColor.White;
            Grid.GridLinesVisibility = GridLinesVisibility.Vertical;
            Grid.ColumnHeaderBackgroundColor = ColorEx.FromARGB(0xFF, 0x77, 0x88, 0x98);
            Grid.ColumnHeaderTextColor = UIColor.White;
            Grid.ColumnHeaderFont = UIFont.BoldSystemFontOfSize(UIFont.LabelFontSize);
            Grid.SelectionBackgroundColor = ColorEx.FromARGB(0xFF, 0xFA, 0xD1, 0x27);
            Grid.SelectionTextColor = UIColor.Black;
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