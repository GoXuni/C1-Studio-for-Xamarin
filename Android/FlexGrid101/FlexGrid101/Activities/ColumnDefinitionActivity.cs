
using Android.App;
using Android.Content.PM;
using Android.OS;
using C1.Android.Grid;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;
using Android.Util;

namespace FlexGrid101
{
    [Activity(Label = "@string/ColumnDefinitionTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class ColumnDefinitionActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.ColumnDefinitionTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new GridColumn { Binding = "Active", Width = new GridLength(TypedValue.ApplyDimension(ComplexUnitType.Dip, 35, Resources.DisplayMetrics)) });
            grid.Columns.Add(new GridColumn { Binding = "FirstName" });
            grid.Columns.Add(new GridColumn { Binding = "LastName" });
            grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Format = "C", InputType = Android.Text.InputTypes.NumberFlagSigned });
            grid.Columns.Add(new GridColumn { Binding = "CountryId", Header = "Country" });
            grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", Format = "d", Mode = GridDateTimeColumnMode.Date });
            grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", SortMemberPath = "LastOrderTime", Format = "t", Mode = GridDateTimeColumnMode.Time, Header = "Last Order Time" });
            grid.Columns["CountryId"].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            grid.ItemsSource = Customer.GetCustomerList(100);
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