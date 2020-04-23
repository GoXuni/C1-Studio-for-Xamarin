using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using C1.Android.Grid;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/CellFreezingTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CellFreezingActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CellFreezing);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.CellFreezingTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);

            var data = Customer.GetCustomerList(100);
            grid.AllowMerging = GridAllowMerging.Cells;
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new GridColumn { Binding = "Name" });
            grid.Columns.Add(new GridColumn { Binding = "Address" });
            grid.Columns.Add(new GridColumn { Binding = "City" });
            grid.Columns.Add(new GridColumn { Binding = "Country", AllowMerging = true });
            grid.Columns.Add(new GridColumn { Binding = "PostalCode" });
            grid.Columns.Add(new GridColumn { Binding = "Email" });
            grid.Columns.Add(new GridColumn { Binding = "LastOrderDate" });
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