
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Util;
using System.Collections.Generic;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/CustomAppearanceTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CustomAppearanceActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomAppearance);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);

            PopulateEditGrid();
        }

        public FlexGrid Grid { get; set; }

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
            col.HorizontalAlignment = Android.Views.GravityFlags.Left;
            col.Width = new GridLength(TypedValue.ApplyDimension(ComplexUnitType.Dip, 120, Resources.DisplayMetrics));

            // provide auto-complete lists for first and last name columns
            col = Grid.Columns["FirstName"];
            col.DataMap = new GridDataMap() { ItemsSource = Customer.GetFirstNames() };
            col = Grid.Columns["LastName"];
            col.DataMap = new GridDataMap() { ItemsSource = Customer.GetLastNames() };


            col = Grid.Columns["Email"];
            col.InputType = Android.Text.InputTypes.TextVariationEmailAddress;

            // make read-only columns look disabled
            var readOnlyBrush = Color.Argb(0xe0, 0xe0, 0xe0, 0xe0);
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