using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using FlexChart101.DataModel;
using C1.Android.Chart;

namespace FlexChart101
{
    [Activity(Label = "@string/gettingStarted", Icon = "@drawable/icon")]
    public class GettingStartedActivity : Activity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // setting the dark theme
            // FlexChart automatically adjusts to the current theme

            SetTheme(Android.Resource.Style.ThemeHolo);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_getting_started);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            // set the binding for X-axis of FlexChart
            
            Chartinitialization.InitialDefaultChart(mChart, ChartPoint.GetList());

            // set title/footer
            mChart.Header = "FlexChart Sales";
            mChart.Footer = "GrapeCity";
        }
    }
}
