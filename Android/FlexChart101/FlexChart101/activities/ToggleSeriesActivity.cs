using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Chart;
using FlexChart101.DataModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/toggleSeries")]
    public class ToggleSeriesActivity : AppCompatActivity
    {
        private FlexChart mChart;
        private Switch mSalesSwitch;
        private Switch mExpensesSwitch;
        private Switch mDownloadsSwitch;
        private ChartSeries mSeriesSales;
        private ChartSeries mSeriesExpenses;
        private ChartSeries mSeriesDownloads;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_toggle_series);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.toggleSeries);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            mSalesSwitch = (Switch)FindViewById(Resource.Id.salesSwitch);
            mExpensesSwitch = (Switch)FindViewById(Resource.Id.expensesSwitch);
            mDownloadsSwitch = (Switch)FindViewById(Resource.Id.downloadsSwitch);
            Chartinitialization.InitialDefaultChart(mChart, ChartPoint.GetList());
            mChart.ChartType = ChartType.Line;
            mChart.LegendToggle = true;
            mSalesSwitch.Checked=true;
            mExpensesSwitch.Checked = true;
            mDownloadsSwitch.Checked = true;
            mSeriesSales = mChart.Series[0] as ChartSeries;
            mSeriesExpenses = mChart.Series[1] as ChartSeries;
            mSeriesDownloads = mChart.Series[2] as ChartSeries;

            mSalesSwitch.CheckedChange += MSalesSwitch_CheckedChange;
            mExpensesSwitch.CheckedChange += MExpensesSwitch_CheckedChange;
            mDownloadsSwitch.CheckedChange += MDownloadsSwitch_CheckedChange;
        }

        private void MSalesSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                mSeriesSales.Visibility = ChartSeriesVisibilityType.Visible;
            else
                mSeriesSales.Visibility = ChartSeriesVisibilityType.Hidden;
        }

        private void MExpensesSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                mSeriesExpenses.Visibility = ChartSeriesVisibilityType.Visible;
            else
                mSeriesExpenses.Visibility = ChartSeriesVisibilityType.Hidden;
        }

        private void MDownloadsSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                mSeriesDownloads.Visibility = ChartSeriesVisibilityType.Visible;
            else
                mSeriesDownloads.Visibility = ChartSeriesVisibilityType.Hidden;
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
