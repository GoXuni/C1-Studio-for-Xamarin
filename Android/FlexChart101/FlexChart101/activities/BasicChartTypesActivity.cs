using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlexChart101.DataModel;
using Java.Lang;

using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/basicChartTypes", Icon = "@drawable/icon")]
    public class BasicChartTypesActivity : BaseActivity
    {
        private FlexChart mChart;
        private Spinner mChartTypeSpinner;
        private Spinner mStackingSpinner;
        private Switch mRotatedSwitch;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_basic_chart_types);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.basicChartTypes);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mChart = (FlexChart)FindViewById(Resource.Id.flexchart);
            mChartTypeSpinner = (Spinner)FindViewById(Resource.Id.chartTypeSpinner);
            mStackingSpinner = (Spinner)FindViewById(Resource.Id.stackingSpinner);
            mRotatedSwitch = (Switch)FindViewById(Resource.Id.rotatedSwitch);

            // set the binding for X-axis of FlexChart


            // setting the source of data/items in FlexChart
            dataSource = ChartPoint.GetList();

            Chartinitialization.InitialDefaultChart(mChart, dataSource);

            ArrayAdapter adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.chartTypeSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mChartTypeSpinner.Adapter = adapter1;
            mChartTypeSpinner.ItemSelected += MChartTypeSpinner_ItemSelected;

            // create custom adapter for second spinner and initialize with string
            // array
            ArrayAdapter adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.stackingSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mStackingSpinner.Adapter = adapter2;
            mStackingSpinner.ItemSelected += MStackingSpinner_ItemSelected;
            mRotatedSwitch.CheckedChange += MRotatedSwitch_CheckedChange;


            mChart.SelectionMode = ChartSelectionModeType.Point;
            mChart.SelectionStyle = new ChartStyle();
            mChart.SelectionStyle.StrokeDashArray = new double[] { 10, 10 };
            
            mChart.SelectionStyle.Stroke = Color.Red;
            mChart.SelectionStyle.StrokeThickness = 3;

          //  mChart.SetBackgroundColor(Color.Gray);
        }

        private void MChartTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var axisX = mChart.AxisX;
            // set chartType based on user selection
            switch (e.Position)
            {
                case 0:
                    mChart.ChartType=ChartType.Area;
                    axisX.MajorGridStyle.StrokeThickness=1;
                    axisX.MinorGridStyle.StrokeThickness = 0;
                    break;
                case 1:
                    mChart.ChartType=ChartType.SplineArea;
                    axisX.MajorGridStyle.StrokeThickness = 1;
                    axisX.MinorGridStyle.StrokeThickness = 0;
                    break;
                case 2:
                    mChart.ChartType=ChartType.SplineSymbols;
                    axisX.MajorGridStyle.StrokeThickness = 1;
                    axisX.MinorGridStyle.StrokeThickness = 0;
                    break;
                case 3:
                    mChart.ChartType=ChartType.Spline;
                    axisX.MajorGridStyle.StrokeThickness = 1;
                    axisX.MinorGridStyle.StrokeThickness = 0;
                    break;
                case 4:
                    mChart.ChartType=ChartType.LineSymbols;
                    axisX.MajorGridStyle.StrokeThickness = 1;
                    axisX.MinorGridStyle.StrokeThickness = 0;
                    break;
                case 5:
                    mChart.ChartType=ChartType.Line;
                    axisX.MajorGridStyle.StrokeThickness = 1;
                    axisX.MinorGridStyle.StrokeThickness = 0;
                    break;
                case 6:
                    mChart.ChartType=ChartType.Scatter;
                    axisX.MajorGridStyle.StrokeThickness = 1;
                    axisX.MinorGridStyle.StrokeThickness = 0;
                    break;
                case 7:
                    mChart.ChartType=ChartType.Bar;
                    axisX.MajorGridStyle.StrokeThickness = 0;
                    axisX.MinorGridStyle.StrokeThickness = 1;
                    break;
                case 8:
                    mChart.ChartType=ChartType.Column;
                    axisX.MajorGridStyle.StrokeThickness = 0;
                    axisX.MinorGridStyle.StrokeThickness = 1;
                    break;
            }
        }


        private void MRotatedSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            mChart.Rotated = e.IsChecked;
        }

        private void MStackingSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    mChart.Stacking = ChartStackingType.None;
                    break;
                case 1:
                    mChart.Stacking = ChartStackingType.Stacked;
                    break;
                case 2:
                    mChart.Stacking = ChartStackingType.Stacked100pc;
                    break;
            }
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

