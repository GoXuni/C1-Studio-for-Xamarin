using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using C1.Android.Chart;
using FlexChart101.DataModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/stylingSeries")]
    public class StylingSeriesActivity : AppCompatActivity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_styling_series);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.stylingSeries);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);

            mChart.BindingX= "Name";

            // initialize series elements and set the binding to variables of
            // ChartPoint
            ChartSeries seriesSales = new ChartSeries();
            seriesSales.Chart = mChart;
            seriesSales.SeriesName = "Sales";
            seriesSales.Binding = "Sales";

            ChartSeries seriesExpenses = new ChartSeries();
            seriesExpenses.Chart = mChart;
            seriesExpenses.SeriesName = "Expenses";
            seriesExpenses.Binding = "Expenses";

            ChartSeries seriesDownloads = new ChartSeries();
            seriesDownloads.Chart = mChart;
            seriesDownloads.SeriesName = "Downloads";
            seriesDownloads.Binding = "Downloads";

            // style series sales
            seriesSales.Style = new ChartStyle() {Fill= Android.Graphics.Color.ParseColor("#009400") , Stroke= Android.Graphics.Color.Green , StrokeThickness=3};

            // style series expenses
            seriesExpenses.Style = new ChartStyle() { Fill = Android.Graphics.Color.ParseColor("#C40000"), Stroke = Android.Graphics.Color.Red, StrokeThickness = 3 };

            // style series downloads
            seriesDownloads.ChartType = ChartType.LineSymbols;
            seriesDownloads.Style = new ChartStyle() {Stroke = Android.Graphics.Color.Blue, StrokeThickness = 10 };
            seriesDownloads.SymbolStyle = new ChartStyle() { Fill = Android.Graphics.Color.Yellow, Stroke = Android.Graphics.Color.Cyan, StrokeThickness = 3 };

            // add series to list
            mChart.Series.Add(seriesSales);
            mChart.Series.Add(seriesExpenses);
            mChart.Series.Add(seriesDownloads);

            // setting the source of data/items in FlexChart
            mChart.ItemsSource=(ChartPoint.GetList());
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
