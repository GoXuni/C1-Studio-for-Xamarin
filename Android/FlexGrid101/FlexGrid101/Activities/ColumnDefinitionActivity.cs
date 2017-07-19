
using Android.App;
using Android.Content.PM;
using Android.OS;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/ColumnDefinitionTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class ColumnDefinitionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new GridColumn { Binding = "Active", Width = new GridLength(70) });
            grid.Columns.Add(new GridColumn { Binding = "FirstName" });
            grid.Columns.Add(new GridColumn { Binding = "LastName" });
            grid.Columns.Add(new GridColumn { Binding = "OrderTotal", Format = "C", InputType = Android.Text.InputTypes.NumberFlagSigned });
            grid.Columns.Add(new GridColumn { Binding = "CountryId", Header = "Country" });
            grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", Format = "d", Mode = GridDateTimeColumnMode.Date });
            grid.Columns.Add(new GridDateTimeColumn { Binding = "LastOrderDate", SortMemberPath = "LastOrderTime", Format = "t", Mode = GridDateTimeColumnMode.Time, Header = "Last Order Time" });
            grid.Columns["CountryId"].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            grid.ItemsSource = Customer.GetCustomerList(100);
        }
    }
}