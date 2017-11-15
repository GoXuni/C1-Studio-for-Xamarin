
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using C1.Android.Grid;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace FlexGrid101
{
    [Activity(Label = "@string/FullTextFilterTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class FullTextFilterActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FullTextFilter);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.FullTextFilterTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            var entry = FindViewById<EditText>(Resource.Id.Filter);
            grid.ItemsSource = Customer.GetCustomerList(100);

            var fullTextFilter = new FullTextFilterBehavior();
            fullTextFilter.Attach(grid);
            fullTextFilter.HighlightColor = global::Android.Graphics.Color.ParseColor("#B00F50");
            fullTextFilter.FilterEntry = entry;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}