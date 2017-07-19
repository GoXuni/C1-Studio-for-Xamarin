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
    [Activity(Label = "@string/theming", Icon = "@drawable/icon")]
    public class ThemingActivity : Activity
    {
        private FlexChart mChart;
        private Spinner mPalette_spinner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_theming);

            // initializing widget
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            mPalette_spinner = (Spinner)FindViewById(Resource.Id.paletteSpinner);
            Chartinitialization.InitialDefaultChart(mChart, ChartPoint.GetList());

            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.paletteSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mPalette_spinner.Adapter=adapter;
            mPalette_spinner.ItemSelected += MPalette_spinner_ItemSelected;
        }

        private void MPalette_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // set palette based on spinner value
            switch (e.Position)
            {
                case 0:
                    mChart.Palette = Palette.Standard;
                    break;
                case 1:
                    mChart.Palette = Palette.Cocoa;
                    break;
                case 2:
                    mChart.Palette = Palette.Coral;
                    break;
                case 3:
                    mChart.Palette = Palette.Dark;
                    break;
                case 4:
                    mChart.Palette = Palette.Highcontrast;
                    break;
                case 5:
                    mChart.Palette = Palette.Light;
                    break;
                case 6:
                    mChart.Palette = Palette.Midnight;
                    break;
                case 7:
                    mChart.Palette = Palette.Minimal;
                    break;
                case 8:
                    mChart.Palette = Palette.Modern;
                    break;
                case 9:
                    mChart.Palette = Palette.Organic;
                    break;
                case 10:
                    mChart.Palette = Palette.Slate;
                    break;
                case 11:
                    mChart.Palette = Palette.Zen;
                    break;
                case 12:
                    mChart.Palette = Palette.Cyborg;
                    break;
                case 13:
                    mChart.Palette = Palette.Superhero;
                    break;
                case 14:
                    mChart.Palette = Palette.Flatly;
                    break;
                case 15:
                    mChart.Palette = Palette.Darkly;
                    break;
                case 16:
                    mChart.Palette = Palette.Cerulean;
                    break;
            }
        }
    }
}
