using System;
using System.Collections.Generic;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class CustomAppearanceController : UIViewController
    {
        public CustomAppearanceController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PopulateEditGrid();
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
        private void PopulateEditGrid()
        {
            // create the data
            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;

            // hide read-only "Country" column 
            var col = Grid.Columns["Country"];
            col.IsVisible = false;

            // map countryID column so it shows country names instead of their IDs
            Dictionary<int, string> dct = new Dictionary<int, string>();
            foreach (var country in Customer.GetCountries())
            {
                dct[country.Key] = country.Value;
            }
            col = Grid.Columns["CountryID"];
            col.DataMap = new GridDataMap() { ItemsSource = dct, DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            col.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            col.Width = new GridLength(120);

            // provide auto-complete lists for first and last name columns
            col = Grid.Columns["FirstName"];
            col.DataMap = new GridDataMap() { ItemsSource = Customer.GetFirstNames() };
            col = Grid.Columns["LastName"];
            col.DataMap = new GridDataMap() { ItemsSource = Customer.GetLastNames() };


            col = Grid.Columns["Email"];
            col.InputType = UIKeyboardType.EmailAddress;

            // make read-only columns look disabled
            var readOnlyBrush = UIColor.FromRGBA(0xe0, 0xe0, 0xe0, 0xe0);
            foreach (var c in Grid.Columns)
            {
                if (c.PropertyInfo != null && !c.PropertyInfo.CanWrite)
                {
                    c.BackgroundColor = readOnlyBrush;
                }
            }

            Grid.Columns.Move(Grid.Columns["Name"].Index, 1);
        }

    }
}