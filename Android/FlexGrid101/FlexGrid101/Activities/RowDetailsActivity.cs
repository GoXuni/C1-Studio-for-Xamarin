
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using C1.Android.Grid;

namespace FlexGrid101
{
    [Activity(Label = "@string/RowDetailsTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class RowDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);

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