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
    [Activity(Label = "@string/mixedChartTypes", Icon = "@drawable/icon")]
    public class MixedChartTypesActivity : Activity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_mixed_chart_types);

            // initializing widgets
            mChart = (FlexChart)FindViewById(Resource.Id.flexchart);

            Chartinitialization.InitialDefaultChart(mChart,ChartPoint.GetList());
            (mChart.Series[2] as ChartSeries).ChartType = ChartType.Line;            
        }
    }
}
