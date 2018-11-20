using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using C1.Android.Grid;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/StarSizingTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class StarSizingActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.StarSizingTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var dips_50 = TypedValue.ApplyDimension(ComplexUnitType.Dip, 50, Resources.DisplayMetrics);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            grid.HeadersVisibility = GridHeadersVisibility.Column;
            grid.BackgroundColor = Color.White;
            grid.RowBackgroundColor = Color.Argb(0xFF, 0xE5, 0xE6, 0xFA);
            grid.RowTextColor = Color.Black;
            grid.AlternatingRowBackgroundColor = Color.White;
            grid.GridLinesVisibility = GridLinesVisibility.Vertical;
            grid.ColumnHeaderBackgroundColor = Color.Argb(0xFF, 0x77, 0x88, 0x98);
            grid.ColumnHeaderTextColor = Color.White;
            grid.ColumnHeaderTypeface = Typeface.Create("", TypefaceStyle.Bold);
            grid.SelectionBackgroundColor = Color.Argb(0xFF, 0xFA, 0xD1, 0x27);
            grid.SelectionTextColor = Color.Black;
            grid.AutoGenerateColumns = false;
            grid.AllowResizing = GridAllowResizing.None;
            grid.DefaultRowHeight = new GridLength(dips_50);
            grid.Columns.Add(new GridColumn { Binding = "FirstName", Width = GridLength.Star });
            grid.Columns.Add(new GridColumn { Binding = "LastName", Width = GridLength.Star });
            grid.Columns.Add(new GridColumn { Binding = "LastOrderDate", Width = GridLength.Star, Format = "d" });
            grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Width = GridLength.Star, Format = "N", HorizontalAlignment = Android.Views.GravityFlags.Right });
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
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