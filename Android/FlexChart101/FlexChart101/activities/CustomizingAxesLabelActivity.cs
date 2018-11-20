
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Chart;
using FlexChart101.DataModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "CustomizingAxesLabelActivity")]
    public class CustomizingAxesLabelActivity : AppCompatActivity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_customizing_axes);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.customizingAxes);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // Create your application here
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);

            // set the binding for X-axis of FlexChart
            mChart.BindingX = "Name";

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

            // add series to list
            mChart.Series.Add(seriesSales);
            mChart.Series.Add(seriesExpenses);

            // setting the source of data/items in FlexChart
            mChart.ItemsSource = ChartPoint.GetList();

            // customize the axis title and format
            // properties set in XML layout
            mChart.AxisX.Title = "Country";

            mChart.AxisY.MinorTickMarks = ChartTickMarkType.Cross;
            mChart.AxisY.MajorGridStyle = new ChartStyle() { StrokeThickness = 1, Stroke = Color.ParseColor("#C4C4C4") };
            mChart.AxisY.MinorGrid = true;
            mChart.AxisY.MinorGridStyle = new ChartStyle() { StrokeThickness = 0.5f, StrokeDashArray = new double[] { 4, 4 } };
            mChart.AxisY.MajorUnit = 2000;

            mChart.AxisX.LabelLoading += (object sender, AxisLabelLoadingEventArgs e) =>
            {
                int[] imageResources = { Resource.Drawable.US, Resource.Drawable.Germany, Resource.Drawable.UK, Resource.Drawable.Japan, Resource.Drawable.Italy, Resource.Drawable.Greece };
                int imgId = imageResources[e.Index];
                Bitmap bmp = BitmapFactory.DecodeResource(this.Resources, imgId);
                ImageView view = new ImageView(this.BaseContext);
                view.SetImageBitmap(bmp);
                e.Label = view;
            };

            mChart.AxisY.LabelLoading += (object sender, AxisLabelLoadingEventArgs e) =>
            {
                TextView textView = new TextView(this.BaseContext);
                textView.Text = "$" + (e.Value / 1000).ToString() + "K";
                textView.Gravity = GravityFlags.Center;
                if (e.Value <= 8000)
                {
                    textView.SetTextColor(Color.Red);
                }
                else if (e.Value <= 12000 && e.Value > 8000)
                {
                    textView.SetTextColor(Color.Green);
                }
                else
                {
                    textView.SetTextColor(Color.Black);
                }
                e.Label = textView;
            };
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
