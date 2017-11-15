using System;
using Android.App;
using Android.OS;
using System.Collections.Generic;
using FlexChart101.DataModel;
using Android.Graphics;
using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace FlexChart101
{
    [Activity(Label = "@string/multipleAxes", Icon = "@drawable/icon")]
    public class MultipleAxesActivity : AppCompatActivity

    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_multiple_axes);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.multipleAxes);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            mChart.LegendPosition = ChartPositionType.None;

            // set the binding for X-axis of FlexChart
            mChart.BindingX = "Month";

            // initialize series elements and set the binding to variables of
            // ChartPoint
            ChartSeries seriesPrecipitation = new ChartSeries();
            seriesPrecipitation.Chart = mChart;
            seriesPrecipitation.SeriesName = "Precipitation";
            seriesPrecipitation.Binding = "Precipitation";
            ChartSeries seriesTemperature = new ChartSeries();
            seriesTemperature.Chart = mChart;
            seriesTemperature.SeriesName = "Temperature";
            seriesTemperature.Binding = "Temperature";

            // add series to list
            mChart.Series.Add(seriesPrecipitation);
            mChart.Series.Add(seriesTemperature);

            // setting the source of data/items and default values in FlexChart
            mChart.ItemsSource = GetList();
            seriesTemperature.ChartType = ChartType.SplineSymbols;

            // format y-axis
            // properties set in XMl layout
            mChart.AxisY.Title = "Precipitation (in)";
            // mChart.AxisY.TitleFontSize(15);
            mChart.AxisY.MajorUnit = 2;

            mChart.AxisY.TitleStyle = new ChartStyle();
            mChart.AxisY.TitleStyle.Stroke = Color.ParseColor("#88bde6");
            mChart.AxisY.AxisLine = false;
            mChart.AxisY.Min = 4;
            mChart.AxisY.Max = 20;

            // create a new axis and customize it
            ChartAxis axisYRight = new ChartAxis();
            axisYRight.Chart = mChart;
            axisYRight.Position = ChartPositionType.Right;

            axisYRight.Title = "Avg. Temperature (F)";
            axisYRight.TitleStyle = new ChartStyle();
            axisYRight.TitleStyle.FontSize = 15;
            //axisYRight.Name="RIGHT";
            axisYRight.AxisLine = false;
            axisYRight.MajorGrid = false;
            axisYRight.MinorGrid = false;
            axisYRight.MajorUnit = 10;
            axisYRight.Min = 0;
            axisYRight.Max = 80;
            //axisYRight.MajorTickWidth=0;
            //axisYRight.MinorTickWidth=0;
            //axisYRight.MajorGridWidth=0;
            //axisYRight.MajorTickWidth = 1;
            //mChart.AxisX.MajorTickWidth = 2;

            axisYRight.TitleStyle.Stroke = Color.ParseColor("#fbb258");

            mChart.AxisX.LabelAngle = 90;

            ////add axis to the chart axes observable list
            //mChart.Axes.Add(axisYRight);

            // tie the series to the axis
            seriesTemperature.AxisY = axisYRight;


        }

        // a method to create a list of random objects of type ChartPoint
        private static IList<object> GetList()
        {
            IList<object> list = new List<object>();

            int n = 12; // number of series elements
            String[] month = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                ChartPoint point = new ChartPoint(month[i], random.Next(8, 18) + random.NextDouble(), (int)Math.Tan(i * i) + 70);
                list.Add(point);
            }
            return list;
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
