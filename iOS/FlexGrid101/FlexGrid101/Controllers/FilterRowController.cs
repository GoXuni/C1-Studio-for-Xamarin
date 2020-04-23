using C1.iOS.Grid;
using Foundation;
using System;
using UIKit;

namespace FlexGrid101
{
    public partial class FilterRowController : UIViewController
    {
        public FilterRowController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var data = Customer.GetCustomerList(100);
            Grid.HeadersVisibility = GridHeadersVisibility.All;
            Grid.FrozenRows = 1;
            Grid.AutoGeneratingColumn += (s, e) => { e.Column.MinWidth = 110; e.Column.Width = GridLength.Star; };
            Grid.ItemsSource = data;
            Grid.Rows.Insert(0, new GridFilterRow() { Placeholder = "Enter text filter here", AutoComplete = true });
        }
    }
}