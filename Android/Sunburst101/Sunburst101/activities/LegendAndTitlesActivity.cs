using Android.App;
using Android.Widget;
using Android.OS;
using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace Sunburst101
{
    [Activity(Label = "@string/legend_and_titles", MainLauncher = false, Icon = "@drawable/LegendAndTitles")]

    public class LegendAndTitlesActivity : AppCompatActivity
    {
        private C1Sunburst sunburst;
        private EditText mHeaderValue;
        private EditText mFooterValue;
        private Spinner mLegendSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_legend_and_titles);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.legend_and_titles);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            sunburst = (C1Sunburst)FindViewById(Resource.Id.sunburst);
            mHeaderValue = (EditText)FindViewById(Resource.Id.headerValue);
            mFooterValue = (EditText)FindViewById(Resource.Id.footerValue);
            mLegendSpinner = (Spinner)FindViewById(Resource.Id.legendSpinner);

            // creating a list of objects
            sunburst.ItemsSource = new SunburstViewModel().HierarchicalData;

            sunburst.LegendPosition = ChartPositionType.None;
            sunburst.ToolTipContent = "{}{name}\n{y}";
            sunburst.Header = mHeaderValue.Text;
            sunburst.Footer = mFooterValue.Text;

            // initializing adapter to string array
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.legend_spinner_values, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mLegendSpinner.Adapter = adapter;
            mLegendSpinner.ItemSelected += mLegendSpinner_ItemSelected;
            mHeaderValue.TextChanged += mHeaderValue_TextChanged;
            mFooterValue.TextChanged += mFooterValue_TextChanged;

        }

        void mFooterValue_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            // setting footer value as editText value
            sunburst.Footer = mFooterValue.Text;
        }

        void mHeaderValue_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            // setting header value as editText value
            sunburst.Header = mHeaderValue.Text;
        }

        public void mLegendSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // setting position of legend based on user selection
            switch (e.Position)
            {
                case 0:
                    sunburst.LegendPosition = ChartPositionType.None;
                    break;
                case 1:
                    sunburst.LegendPosition = ChartPositionType.Left;
                    break;
                case 2:
                    sunburst.LegendPosition = ChartPositionType.Top;
                    break;
                case 3:
                    sunburst.LegendPosition = ChartPositionType.Right;
                    break;
                case 4:
                    sunburst.LegendPosition = ChartPositionType.Bottom;
                    break;
                case 5:
                    sunburst.LegendPosition = ChartPositionType.Auto;
                    break;
            }
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