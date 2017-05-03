
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/FullTextFilterTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class FullTextFilterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FullTextFilter);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            var entry = FindViewById<EditText>(Resource.Id.Filter);
            grid.ItemsSource = Customer.GetCustomerList(100);

            var fullTextFilter = new FullTextFilterBehavior();
            fullTextFilter.Attach(grid);
            fullTextFilter.HighlightColor = global::Android.Graphics.Color.ParseColor("#B00F50");
            fullTextFilter.FilterEntry = entry;
        }
    }
}