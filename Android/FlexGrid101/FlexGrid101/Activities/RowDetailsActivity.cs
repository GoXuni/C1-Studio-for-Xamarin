
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using C1.Android.Grid;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace FlexGrid101
{
    [Activity(Label = "@string/RowDetailsTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class RowDetailsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.RowDetailsTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var grid = FindViewById<FlexGrid>(Resource.Id.Grid);

            var data = Customer.GetCustomerList(100);

            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new GridColumn() { Binding = "Id", Width = GridLength.Auto });
            grid.Columns.Add(new GridColumn() { Binding = "FirstName", Width = GridLength.Star });
            grid.Columns.Add(new GridColumn() { Binding = "LastName", Width = GridLength.Star });
            var details = new FlexGridDetailProvider();
            details.Attach(grid);
            details.DetailCellCreating += OnDetailCellCreating;
            details.Height = GridLength.Auto;
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
        private void OnDetailCellCreating(object sender, GridDetailCellCreatingEventArgs e)
        {
            var customer = e.Row.DataItem as Customer;
            var detailsView = LayoutInflater.Inflate(Resource.Layout.RowDetailsCell, null);
            var countryLabel = detailsView.FindViewById<Android.Widget.TextView>(Resource.Id.CountryLabel);
            var cityLabel = detailsView.FindViewById<Android.Widget.TextView>(Resource.Id.CityLabel);
            var addressLabel = detailsView.FindViewById<Android.Widget.TextView>(Resource.Id.AddressLabel);
            var postalCodeLabel = detailsView.FindViewById<Android.Widget.TextView>(Resource.Id.PostalCodeLabel);
            countryLabel.Text = string.Format(Resources.GetString(Resource.String.RowDetailsCountry), customer.Country);
            cityLabel.Text = string.Format(Resources.GetString(Resource.String.RowDetailsCity), customer.City);
            addressLabel.Text = string.Format(Resources.GetString(Resource.String.RowDetailsAddress), customer.Address);
            postalCodeLabel.Text = string.Format(Resources.GetString(Resource.String.RowDetailsPostalCode), customer.PostalCode);
            e.Content = detailsView;
        }
    }
}