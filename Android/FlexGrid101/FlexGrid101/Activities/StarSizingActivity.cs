
using Android.App;
using Android.Content.PM;
using Android.OS;
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