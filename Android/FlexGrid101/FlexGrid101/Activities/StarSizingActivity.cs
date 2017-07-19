
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using C1.Android.Core;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/StarSizingTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class StarSizingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            grid.HeadersVisibility = GridHeadersVisibility.Column;
            grid.BackgroundColor = Color.White;
            grid.RowBackgroundColor = ColorEx.FromARGB(0xFF, 0xE5, 0xE6, 0xFA);
            grid.RowTextColor = Color.Black;
            grid.AlternatingRowBackgroundColor = Color.White;
            grid.GridLinesVisibility = GridLinesVisibility.Vertical;
            grid.ColumnHeaderBackgroundColor = ColorEx.FromARGB(0xFF, 0x77, 0x88, 0x98);
            grid.ColumnHeaderTextColor = Color.White;
            grid.ColumnHeaderTypeface = Typeface.Create("", TypefaceStyle.Bold);
            grid.SelectionBackgroundColor = ColorEx.FromARGB(0xFF, 0xFA, 0xD1, 0x27);
            grid.SelectionTextColor = Color.Black;
            grid.AutoGenerateColumns = false;
            grid.AllowResizing = GridAllowResizing.Columns;
            grid.Columns.Add(new GridColumn { Binding = "FirstName", Width = GridLength.Star });
            grid.Columns.Add(new GridColumn { Binding = "LastName", Width = GridLength.Star });
            grid.Columns.Add(new GridColumn { Binding = "LastOrderDate", Width = GridLength.Star, Format = "d" });
            grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Width = GridLength.Star, Format = "N", HorizontalAlignment = Android.Views.GravityFlags.Right });
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }
    }
}