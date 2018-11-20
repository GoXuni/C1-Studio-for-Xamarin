using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Chart;
using C1.Android.Chart.Interaction;
using System;
using System.Collections.Generic;
using Math = System.Math;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "ZoomingAndScrollingActivity")]
    public class ZoomingAndScrollingActivity : AppCompatActivity
    {

        private FlexChart mChart;
        private Spinner mZoomModeSpinner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_zooming_and_scrolling);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.zoomingAndScrolling);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mChart = (FlexChart)FindViewById(Resource.Id.flexchart);
            mChart.ChartType = ChartType.Scatter;

            mZoomModeSpinner = (Spinner)FindViewById(Resource.Id.zoomModeSpinner);

            mChart.BindingX = "X";
            ChartSeries seriesSales = new ChartSeries();
            seriesSales.Chart = mChart;
            seriesSales.SeriesName = "Normal Distribution";
            seriesSales.Binding = "Y";

            mChart.Series.Add(seriesSales);

            mChart.ItemsSource = GenerateRandNormal(500); 
            //mChart.AxisY.MajorUnit = 1.0;
            mChart.LegendPosition = ChartPositionType.Bottom;

            ZoomBehavior z = new ZoomBehavior();
            mChart.Behaviors.Add(z);

            TranslateBehavior t = new TranslateBehavior();
            mChart.Behaviors.Add(t);

            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.zoomModeSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mZoomModeSpinner.Adapter = adapter;
            mZoomModeSpinner.SetSelection(3);
            mZoomModeSpinner.ItemSelected += mZoomModeSpinner_ItemSelected;
        }

        private void mZoomModeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            ZoomBehavior z = mChart.Behaviors[0] as ZoomBehavior;
            z.ZoomMode = (GestureMode)e.Position;
        }

        Random rnd = new Random();

        List<PointF> GenerateRandNormal(int n)
        {
            if (n % 2 == 1)
                n++;

            List<PointF> points = new List<PointF>(n);

            for (int i = 0; i < n / 2; i++)
            {
                do
                {
                    double u = 2 * rnd.NextDouble() - 1;
                    double v = 2 * rnd.NextDouble() - 1;

                    double s = u * u + v * v;

                    if (s < 1)
                    {
                        s = Math.Sqrt(-2 * Math.Log(s) / s);
                        points.Add(new PointF(i, (float)(u * s)));
                        points.Add(new PointF(i + 1, (float)(v * s)));
                        break;
                    }
                } while (true);
            }

            return points;
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
