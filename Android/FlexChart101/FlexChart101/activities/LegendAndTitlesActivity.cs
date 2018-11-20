using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using C1.Android.Chart;
using FlexChart101.DataModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/legendAndTitles")]
    public class LegendAndTitlesActivity : AppCompatActivity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_legend_and_titles);


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.legendAndTitles);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            Chartinitialization.InitialDefaultChart(mChart, ChartPoint.GetList());
            mChart.ChartType = ChartType.Scatter;
            
            mChart.AxisX.Title="Country";
            mChart.AxisX.MajorGrid=true;
            mChart.AxisY.Title = "Amount";
            
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
