using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using FlexChart101.DataModel;
using C1.Android.Chart;
using C1.Android.Core;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/hitTest", Icon = "@drawable/icon")]
    public class HitTestActivity : AppCompatActivity
    {
        private FlexChart mChart;
        private TextView mHitTestInfo;

        private String chartElement;
        private String chartElementNone;
        private String pointIndex;
        private String seriesName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_hit_test);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.hitTest);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            mChart.BindingX = "Count";

            mHitTestInfo = (TextView)FindViewById(Resource.Id.hitTestInfo);

            mChart.AxisY.Format="#.##";

            chartElement = this.Resources.GetString(Resource.String.hitTestChartElement);
            chartElementNone = this.Resources.GetString(Resource.String.hitTestChartElementNone);
            pointIndex = this.Resources.GetString(Resource.String.hitTestPointIndex);
            seriesName = this.Resources.GetString(Resource.String.hitTestSeriesName);

            // initialize series elements and set the binding to variables of
            // ChartPoint
            ChartSeries seriesSine = new ChartSeries();
            seriesSine.Chart = mChart;
            seriesSine.SeriesName = "sin(x)";
            seriesSine.Binding = "Sine";

            ChartSeries seriesCosine = new ChartSeries();
            seriesCosine.Chart = mChart;
            seriesCosine.SeriesName = "cos(x)";
            seriesCosine.Binding = "Cosine";

            // setup individual series item source
            int len = 40;
            List<object> list = new List<object>();

            for (int i = 0; i < len; i++)
            {
                list.Add(new ChartPoint(i, (float)Math.Sin(0.12 * i), (float)Math.Cos(0.12 * i)));
            }
            mChart.ItemsSource = list;

            // add series to list
            mChart.Series.Add(seriesSine);
            mChart.Series.Add(seriesCosine);

            mChart.Tapped += MChart_ChartTapped;

        }

        private void MChart_ChartTapped(object sender, C1TappedEventArgs e)
        {
            C1Point point = e.GetPosition(mChart);
            ChartHitTestInfo info = mChart.HitTest(point);
            // display hitTestInfo for each touch event
            string displayText = string.Empty ;
            if (info != null)
            {
                displayText = chartElement + (info.ChartElement == null ? chartElementNone : info.ChartElement.ToString());
                if (info.Item != null)
                {
                    displayText += "\n" + seriesName + info.Series.Name + "\n" + pointIndex + info.PointIndex;
                    ChartPoint data = (ChartPoint)info.Item;

                    displayText += "\nX : " + data.Count;
                    if (info.Series.Name.Equals("sin(x)"))
                    {
                        displayText += " sin(x) : " + data.Sine;
                    }
                    else
                    {
                        displayText += " cos(x) : " + data.Cosine;
                    }
                }
            }
            else
            {
                displayText = "Well, this is not happening..";
            }
            mHitTestInfo.Text=displayText;
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
