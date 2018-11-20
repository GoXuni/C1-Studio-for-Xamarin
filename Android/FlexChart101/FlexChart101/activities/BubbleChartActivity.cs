using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using C1.Android.Chart;
using FlexChart101.DataModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/bubbleChart")]
    public class BubbleChartActivity : AppCompatActivity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_bubble_chart);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.bubbleChart);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mChart = (FlexChart)FindViewById(Resource.Id.flexchart);
            mChart.ChartType = ChartType.Bubble;
            // set the binding for X-axis of FlexChart
            mChart.BindingX="Name";

            // initialize series elements and set the binding to variables of
            // ChartPoint
            ChartSeries seriesSales = new ChartSeries();
            seriesSales.Chart = mChart;
            seriesSales.SeriesName = "Sales";
            seriesSales.Binding = "Sales,Downloads";

            ChartSeries seriesExpenses = new ChartSeries();
            seriesExpenses.Chart = mChart;
            seriesExpenses.SeriesName = "Expenses";
            seriesExpenses.Binding = "Expenses,Downloads";

            // add series to list
            mChart.Series.Add(seriesSales);
            mChart.Series.Add(seriesExpenses);

            // setting the source of data/items and default values in FlexChart
            mChart.ItemsSource=ChartPoint.GetList();
            // property set in XML layout
            // mChart.setChartType(ChartType.BUBBLE);


            mChart.SelectionMode = ChartSelectionModeType.Point;
            mChart.SelectionStyle = new ChartStyle();
            mChart.SelectionStyle.StrokeDashArray = new double[] { 10, 10 };

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
