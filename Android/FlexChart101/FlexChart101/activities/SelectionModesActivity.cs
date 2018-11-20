using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Chart;
using FlexChart101.DataModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/selectionModes")]
    public class SelectionModesActivity : AppCompatActivity
    {
        private FlexChart mChart;
        private Spinner mChartTypeSpinner;
        private Spinner mSelectionModeSpinner;

        private const string SELECTED_SERIES_NAME = "SELECTED_SERIES_NAME";
        private const string SELECTED_ELEMENT_INDEX = "SELECTED_ELEMENT_INDEX";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_selection_modes);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.selectionModes);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            mChart = (FlexChart)FindViewById(Resource.Id.flexchart);
            mChartTypeSpinner = (Spinner)FindViewById(Resource.Id.chartTypeSpinner);
            mSelectionModeSpinner = (Spinner)FindViewById(Resource.Id.selectionModeSpinner);
            Chartinitialization.InitialDefaultChart(mChart, ChartPoint.GetList());

            mChart.SelectionStyle =new ChartStyle();
            mChart.SelectionStyle.Stroke = Android.Graphics.Color.Red;


            // create custom adapter for first spinner and initialize with string
            // array
            ArrayAdapter adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.chartTypeSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mChartTypeSpinner.Adapter=adapter1;
            mChartTypeSpinner.ItemSelected += MChartTypeSpinner_ItemSelected;

            // create custom adapter for second spinner and initialize with string
            // array
            ArrayAdapter adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.selectionModeSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mSelectionModeSpinner.Adapter=adapter2;
            mSelectionModeSpinner.ItemSelected += MSelectionModeSpinner_ItemSelected;

        }

        private void MSelectionModeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    mChart.SelectionMode=ChartSelectionModeType.Point;
                    break;
                case 1:
                    mChart.SelectionMode= ChartSelectionModeType.Series;
                    break;
                case 2:
                    mChart.SelectionMode= ChartSelectionModeType.None;
                    break;
            }
        }

        private void MChartTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    mChart.ChartType = ChartType.Area;
                    break;
                case 1:
                    mChart.ChartType = ChartType.SplineArea;
                    break;
                case 2:
                    mChart.ChartType = ChartType.SplineSymbols;
                    break;
                case 3:
                    mChart.ChartType = ChartType.Spline;
                    break;
                case 4:
                    mChart.ChartType = ChartType.LineSymbols;
                    break;
                case 5:
                    mChart.ChartType = ChartType.Line;
                    break;
                case 6:
                    mChart.ChartType = ChartType.Scatter;
                    break;
                case 7:
                    mChart.ChartType = ChartType.Bar;
                    break;
                case 8:
                    mChart.ChartType = ChartType.Column;
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
