using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using FlexChart101.DataModel;

using Android.Graphics;
using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace FlexChart101
{
	[Activity(Label = "@string/dataLabels", Icon = "@drawable/icon")]
	public class DataLabelsActivity : AppCompatActivity
    {
		private FlexChart mChart;
		private Spinner mDataLabelSpinner;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_data_labels);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.dataLabels);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);

			mDataLabelSpinner = (Spinner)FindViewById(Resource.Id.dataLabelSpinner);

			// set the binding for X-axis of FlexChart
			mChart.BindingX = "Name";

			// initialize series elements and set the binding to variables of
			// ChartPoint
			ChartSeries seriesSales = new ChartSeries();
			seriesSales.Chart = mChart;
			seriesSales.SeriesName = "Sales";
			seriesSales.Binding = "Sales";

			// add series to list
			mChart.Series.Add(seriesSales);

			// setting the source of data/items in FlexChart
			mChart.ItemsSource = ChartPoint.GetList();

			mChart.ChartType = ChartType.Bar;

			mChart.DataLabel.Content = "{x},{y}";
			mChart.DataLabel.Border = true;
			mChart.DataLabel.BorderStyle = new ChartStyle() { Stroke = Color.Green, StrokeThickness = 2, Fill = Color.Transparent };

			// create custom adapter for spinner and initialize with string array
			ArrayAdapter adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.chartDataLabelPositionSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
			// Specify the layout to use when the list of choices appears
			adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			// Apply the adapter to the spinner
			mDataLabelSpinner.Adapter = adapter1;

			int defaultPosition = adapter1.GetPosition("Left");
			mDataLabelSpinner.SetSelection(defaultPosition);
			mDataLabelSpinner.ItemSelected += MDataLabelSpinner_ItemSelected;
		}

		private void MDataLabelSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			switch (e.Position)
			{
				case 0:
					mChart.DataLabel.Position = ChartLabelPosition.None;
					break;
				case 1:
					mChart.DataLabel.Position = ChartLabelPosition.Left;
					break;
				case 2:
					mChart.DataLabel.Position = ChartLabelPosition.Top;
					break;
				case 3:
					mChart.DataLabel.Position = ChartLabelPosition.Right;
					break;
				case 4:
					mChart.DataLabel.Position = ChartLabelPosition.Bottom;
					break;
				case 5:
					mChart.DataLabel.Position = ChartLabelPosition.Center;
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
