using System;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class ColumnDefinitionsController : UIViewController
    {
        public ColumnDefinitionsController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Grid.AutoGenerateColumns = false;
            Grid.Columns.Add(new GridColumn { Binding = "Active", Width = new GridLength(75) });
            Grid.Columns.Add(new GridColumn { Binding = "FirstName", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "LastName", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Format = "C", InputType = UIKeyboardType.NumbersAndPunctuation, MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn { Binding = "CountryId", Header = "Country", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", Format = "d", Mode = GridDateTimeColumnMode.Date, MinWidth = 110, Width = GridLength.Star });
            Grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", SortMemberPath = "LastOrderTime", Format = "t", Mode = GridDateTimeColumnMode.Time, Header = "Last Order Time", MinWidth = 110, Width = GridLength.Star });
            Grid.Columns["CountryId"].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key"};
            Grid.ItemsSource = Customer.GetCustomerList(100);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }
}