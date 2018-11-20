using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Chart;
using C1.Android.Chart.Interaction;
using C1.Android.Core;
using System;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
    [Activity(Label = "@string/customMarker", Icon = "@drawable/chart_marker")]
    public class CustomMarkerActivity : AppCompatActivity
    {
        private FlexChart mChart;
        private Spinner mLineTypeSpinner;
        private Spinner mAlignmentSpinner;
        private Spinner mInteractiveSpinner;
        private C1LineMarker lineMarker;

        private LinearLayout layout;
        private TextView xLabel;
        private IList<TextView> yLabels = new List<TextView>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_custom_marker);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.customMarker);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            mChart.ItemsSource = new LineMarkerViewModel().Items;
            // initialize series elements and set the binding to variables of
            // ChartPoint
            mChart.ChartType = ChartType.Line;
            mChart.BindingX = "Date";
            ChartSeries inputSeries = new ChartSeries();
            ChartSeries outputSeries = new ChartSeries();
            inputSeries.SeriesName = "Input";
            inputSeries.Binding = "Input";
            outputSeries.SeriesName = "Output";
            outputSeries.Binding = "Output";
            mChart.Series.Add(inputSeries);
            mChart.Series.Add(outputSeries);

            initMarker();
            mChart.Layers.Add(lineMarker);

            mLineTypeSpinner = (Spinner)FindViewById(Resource.Id.lineTypeSpinner);
            ArrayAdapter lineTypeAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.lineMarkerLines, Android.Resource.Layout.SimpleSpinnerItem);
            lineTypeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mLineTypeSpinner.Adapter = lineTypeAdapter;
            mLineTypeSpinner.ItemSelected += MLineTypeSpinner_ItemSelected;

            mAlignmentSpinner = (Spinner)FindViewById(Resource.Id.alignmentSpinner);
            ArrayAdapter alignmentAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.lineMarkerAlignment, Android.Resource.Layout.SimpleSpinnerItem);
            alignmentAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mAlignmentSpinner.Adapter = alignmentAdapter;
            mAlignmentSpinner.ItemSelected += MAlignmentSpinner_ItemSelected;

            mInteractiveSpinner = (Spinner)FindViewById(Resource.Id.interactiveSpinner);
            ArrayAdapter interactiveAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.lineMarkerInteraction, Android.Resource.Layout.SimpleSpinnerItem);
            interactiveAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mInteractiveSpinner.Adapter = interactiveAdapter;
            mInteractiveSpinner.ItemSelected += MInteractiveSpinner_ItemSelected;

        }

        private void MLineTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    lineMarker.Lines = LineMarkerLines.None;
                    break;
                case 1:
                    lineMarker.Lines = LineMarkerLines.Vertical;
                    break;
                case 2:
                    lineMarker.Lines = LineMarkerLines.Horizontal;
                    break;
                case 3:
                    lineMarker.Lines = LineMarkerLines.Both;
                    break;
            }
        }
        private void MAlignmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    lineMarker.Alignment = LineMarkerAlignment.Auto;
                    break;
                case 1:
                    lineMarker.Alignment = LineMarkerAlignment.Bottom;
                    break;
                case 2:
                    lineMarker.Alignment = LineMarkerAlignment.Left;
                    break;
                case 3:
                    lineMarker.Alignment = LineMarkerAlignment.Right;
                    break;
                case 4:
                    lineMarker.Alignment = LineMarkerAlignment.Top;
                    break;
            }
        }
        private void MInteractiveSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    lineMarker.Interaction = LineMarkerInteraction.Move;
                    break;
                case 1:
                    lineMarker.Interaction = LineMarkerInteraction.Drag;
                    break;
                case 2:
                    lineMarker.Interaction = LineMarkerInteraction.None;
                    break;
            }
        }

        private void initMarker()
        {
            lineMarker = new C1LineMarker(this);
            lineMarker.DragContent = true;
            layout = new LinearLayout(this);
            layout.Orientation = Android.Widget.Orientation.Vertical;
            layout.SetPadding(10,10,10,10);
            layout.SetBackgroundColor(Color.Gray);
            xLabel = new TextView(this);

            layout.AddView(xLabel);

            for (int index = 0; index < mChart.Series.Count; index++)
            {
                var series = mChart.Series[index];
                var fill = (int)((IChart)mChart).GetColor(index);
                TextView yLabel = new TextView(this);
                var bytes = BitConverter.GetBytes(fill);
                yLabel.SetTextColor(new Color(fill));

                yLabels.Add(yLabel);
                layout.AddView(yLabel);

            }
            lineMarker.Content = layout;

            lineMarker.PositionChanged += LineMarker_PositionChanged;
        }

        private void LineMarker_PositionChanged(object sender, PositionChangedArgs e)
        {
            if (mChart != null)
            {
                var info = mChart.HitTest(new C1Point(e.Position.X, double.NaN));
                int pointIndex = info.PointIndex;
                xLabel.Text = string.Format("{0:MM-dd}", info.X);

                for (int index = 0; index < mChart.Series.Count; index++)
                {
                    var series = mChart.Series[index];
                    var value = series.GetValues(0)[pointIndex];

                    var fill = (int)((IChart)mChart).GetColor(index);
                    string content = string.Format("{0} = {1}", series.SeriesName, string.Format("{0:f0}", value));
                    TextView yLabel = yLabels[index];
                    yLabel.Text = content;

                }
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
