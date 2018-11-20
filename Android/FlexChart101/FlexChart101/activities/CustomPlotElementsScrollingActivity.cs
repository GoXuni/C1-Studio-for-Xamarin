using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Chart;
using C1.Android.Chart.Interaction;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "CustomPlotElementsActivity")]
    public class CustomPlotElementsScrollingActivity : AppCompatActivity
    {
        private FlexChart mChart;
        int[] imageResources = { Resource.Drawable.logo_apple, Resource.Drawable.logo_google, Resource.Drawable.logo_microsoft };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.activity_custom_plot_elements);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.customPlotElementsScrolling);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);

            // set the binding for X-axis of FlexChart
            mChart.BindingX = "name";

            // initialize series elements and set the binding to variables of
            // ChartPoint
            ChartSeries seriesdevices = new ChartSeries();
            seriesdevices.Chart = mChart;
            seriesdevices.SeriesName = "Devices sold";
            seriesdevices.Binding = "devicesSold";
            // add series to list
            mChart.Series.Add(seriesdevices);

            // setting the source of data/items in FlexChart
            mChart.ItemsSource = CustomPoint.GetList(this);

            // Set axis Y title.
            mChart.AxisY.Title = "Devices Sold (billions)";
            // Set axis Y line invisible.
            mChart.AxisY.AxisLine = false;

            seriesdevices.SymbolLoading += (object sender, SymbolEventArgs e) =>
            {
                int index = e.Index;
                ImageView view = new ImageView(this.BaseContext);
                Bitmap logo = BitmapFactory.DecodeResource(this.BaseContext.Resources, imageResources[index]);
                view.SetImageBitmap(logo);
                e.PlotElement.Content = view;
            };

            TranslateBehavior t = new TranslateBehavior();
            mChart.Behaviors.Add(t);

            mChart.AxisX.Scale = 0.2;

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
