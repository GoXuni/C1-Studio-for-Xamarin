using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using C1.Android.Core;

namespace FlexChart101
{
    [Activity(Label = "@string/updateAnimation", Icon = "@drawable/chart_animation")]
    public class UpdateAnimationActivity : BaseActivity
    {
        private FlexChart mChart;
        private Spinner mChartTypeSpinner;
        private Spinner mUpdatePositionSpinner;
        private int mUpdatePosition;
        private Button mButtonAdd;
        private Button mButtonRemove;
        private int mMaxValue = 50;
        private int mMinDataLimit = 1;
        private Random mRandom = new Random();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_update_animation);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.updateAnimation);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mChart = (FlexChart)FindViewById(Resource.Id.flexchart);
            mChartTypeSpinner = (Spinner)FindViewById(Resource.Id.chartTypeSpinner);
            mUpdatePositionSpinner = (Spinner)FindViewById(Resource.Id.updatePositionSpinner);
            mButtonAdd = (Button)FindViewById(Resource.Id.buttonAddPoint);
            mButtonRemove = (Button)FindViewById(Resource.Id.buttonRemovePoint);
            mButtonAdd.Click += ButtonAdd_Click;
            mButtonRemove.Click += ButtonRemove_Click;

            // setting the source of data/items in FlexChart
            IList<object> list = GetList();
            dataSource = new ObservableCollection<object>(list);
            mChart.ItemsSource = dataSource;
            mChart.BindingX = "Letter";
		    // initialize series elements and set the binding to variables of
		    // ChartPoint
		    ChartSeries seriesSales = new ChartSeries();
            seriesSales.Chart = mChart;
            seriesSales.SeriesName = "Value";
            seriesSales.Binding = "Count";
            // add series to list
            mChart.Series.Add(seriesSales);

            mChart.Palette = Palette.Cocoa;
            
            C1Animation updateAnimation = new C1Animation();
            updateAnimation.Duration = new TimeSpan(1500 * 10000);
            updateAnimation.Easing = C1Easing.Linear;
            mChart.UpdateAnimation = updateAnimation;
            mChart.AnimationMode = AnimationMode.All;

            ArrayAdapter adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.chartTypeSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mChartTypeSpinner.Adapter = adapter1;
            mChartTypeSpinner.ItemSelected += MChartTypeSpinner_ItemSelected;
            mChartTypeSpinner.SetSelection(8);

            ArrayAdapter adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.updatePositionSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mUpdatePositionSpinner.Adapter = adapter2;
            mUpdatePositionSpinner.ItemSelected += MUpdatePositionSpinner_ItemSelected;

            mChart.SelectionMode = ChartSelectionModeType.Point;
            mChart.SelectionStyle = new ChartStyle();
            mChart.SelectionStyle.StrokeDashArray = new double[] { 10, 10 };
            
            mChart.SelectionStyle.Stroke = Color.Red;
            mChart.SelectionStyle.StrokeThickness = 3;
            
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

        private void MUpdatePositionSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            mUpdatePosition = e.Position;
        }

        private void ButtonAdd_Click(object sender, System.EventArgs e)
        {
            // add a new point at location denoted by updatePosition
            switch (mUpdatePosition)
            {
                case 0:
                    dataSource.Insert(0, new ChartPoint((char)(mRandom.Next(26) + 65), mRandom.Next(mMaxValue)));
                    break;
                case 1:
                    dataSource.Insert((dataSource.Count / 2),
                            new ChartPoint((char)(mRandom.Next(26) + 65), mRandom.Next(mMaxValue)));
                    break;
                case 2:
                    dataSource.Add(new ChartPoint((char)(mRandom.Next(26) + 65), mRandom.Next(mMaxValue)));
                    break;
            }

            if (dataSource.Count > mMinDataLimit)
                mButtonRemove.Enabled = true;
        }
        private void ButtonRemove_Click(object sender, System.EventArgs e)
        {
            // remove a point at location denoted by updatePosition
            switch (mUpdatePosition)
            {
                case 0:
                    dataSource.RemoveAt(0);
                    break;
                case 1:
                    dataSource.RemoveAt((dataSource.Count / 2));
                    break;
                case 2:
                    dataSource.RemoveAt(dataSource.Count - 1);
                    break;
            }
            if (dataSource.Count <= mMinDataLimit)
                mButtonRemove.Enabled= false;
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

        
        private IList<object> GetList()
        {
            IList<object> list = new List<object>();
            Random random = new Random();
            int n = 10; // number of series elements

            for (int i = 0; i < n; i++)
            {
                list.Add(new ChartPoint((char)(random.Next(26) + 65), random.Next(mMaxValue)));
            }
            return list;
        }
    }
}

