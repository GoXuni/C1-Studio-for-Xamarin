using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using FlexChart101.DataModel;
using C1.Android.Chart;

namespace FlexChart101
{
    [Activity(Label = "@string/legendAndTitles", Icon = "@drawable/icon")]
    public class LegendAndTitlesActivity : Activity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_legend_and_titles);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            Chartinitialization.InitialDefaultChart(mChart, ChartPoint.GetList());
            mChart.ChartType = ChartType.Scatter;
            
            mChart.AxisX.Title="Country";
            mChart.AxisX.MajorGrid=true;
            mChart.AxisY.Title = "Amount";
            
        }
    }
}
