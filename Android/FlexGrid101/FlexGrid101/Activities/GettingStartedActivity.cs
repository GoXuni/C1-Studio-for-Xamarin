
using Android.App;
using Android.Content.PM;
using Android.OS;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/GettingStartedTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class GettingStartedActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            grid.ItemsSource = Customer.GetCustomerList(100);
        }
    }
}