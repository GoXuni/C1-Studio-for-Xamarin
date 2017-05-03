
using Android.App;
using Android.Content.PM;
using Android.OS;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/CellFreezingTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CellFreezingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CellFreezing);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.Columns["Country"].AllowMerging = true;
        }
    }
}