using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using C1.Android.Gauge;
using Android.Graphics;
using Java.Util;

namespace C1Gauge101
{
    [Activity(Label = "@string/displaying_values", MainLauncher = false, Icon = "@drawable/gauge_radial")]
    public class DisplayingValuesActivity : Activity
    {
        private C1LinearGauge mLinearGauge;
        private Spinner mShowTextSpinner;
        private C1RadialGauge mRadialGauge;
        //private GaugeRangeCollection mRanges = new GaugeRangeCollection();
        private double mValue = .25;
        private TextView mValueText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_displaying_values);

            // initializing widgets
            mLinearGauge = (C1LinearGauge)FindViewById(Resource.Id.linearGauge1);
            mRadialGauge = (C1RadialGauge)FindViewById(Resource.Id.radialGauge1);
            mShowTextSpinner = (Spinner)FindViewById(Resource.Id.showTextSpinner);
            mValueText = (TextView)FindViewById(Resource.Id.valueText);

            // creating and initializing adapter to string array
            ArrayAdapter adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.showTextSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mShowTextSpinner.Adapter = adapter1;
            mShowTextSpinner.ItemSelected += mShowTextSpinner_ItemSelected;

            // setting dafault values
            mValueText.Text = ((int)(mValue * 100)).ToString();

            mLinearGauge.ShowText = GaugeShowText.All;
            mRadialGauge.ShowText = GaugeShowText.All;

            setRange(0, 40, -65536);
            setRange(40, 80, -256);
            setRange(80, 100, -16711936);

            mLinearGauge.Value = mValue;
            mLinearGauge.Min = 0;
            mLinearGauge.Max = 1;
            mLinearGauge.Step = .01f;
            // mLinearGauge.Ranges = mRanges;
            mLinearGauge.ShowRanges = false;
            mLinearGauge.ShowText = GaugeShowText.All;
            //mLinearGauge.GaugeWidth = .5f;
            mLinearGauge.Animate();
            mLinearGauge.Format = "#%";

            mRadialGauge.Value = mValue;
            mRadialGauge.Min = 0;
            mRadialGauge.Max = 1;
            mRadialGauge.Step = .01f;
            //mRadialGauge.Ranges = mRanges;
            mRadialGauge.ShowRanges = false;
            mRadialGauge.ShowText = GaugeShowText.All;
            //mRadialGauge.GaugeWidth = .5f;
            mRadialGauge.Animate();
            mRadialGauge.Format = "#%";

            Button minusButton = (Button)FindViewById(Resource.Id.buttonMinus);
            minusButton.Click += button_Click;
            Button plusButton = (Button)FindViewById(Resource.Id.buttonPlus);
            plusButton.Click += button_Click;
        }


        void mShowTextSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // setting the direction of each gauge and applying a new layout
            switch (e.Position)
            {
                case 0:
                    mLinearGauge.ShowText = GaugeShowText.All;
                    mRadialGauge.ShowText = GaugeShowText.All;
                    break;
                case 1:
                    mLinearGauge.ShowText = GaugeShowText.MinMax;
                    mRadialGauge.ShowText = GaugeShowText.MinMax;
                    break;
                case 2:
                    mLinearGauge.ShowText = GaugeShowText.Value;
                    mRadialGauge.ShowText = GaugeShowText.Value;
                    break;
                case 3:
                    mLinearGauge.ShowText = GaugeShowText.None;
                    mRadialGauge.ShowText = GaugeShowText.None;
                    break;
            }
        }

        private void button_Click(object sender, System.EventArgs e)
        {
            View v = (View)sender;
            switch (v.Id)
            {
                case Resource.Id.buttonMinus:
                    // decrease gauge value
                    mValue -= (mValue > 0) ? .25 : 0;
                    break;
                case Resource.Id.buttonPlus:
                    // increase gauge value
                    mValue += (mValue < 1) ? .25 : 0;
                    break;
            }
            mLinearGauge.Value = mValue;
            mRadialGauge.Value = mValue;
            mValueText.Text = ((int)(mValue * 100)).ToString();
        }

        // a method to create a new range and adding it to the list
        private void setRange(double min, double max, int color)
        {
            GaugeRange range = new GaugeRange();
            range.Min = min;
            range.Max = max;
            range.Color = new Color(color);
            mLinearGauge.Ranges.Add(range);
            mRadialGauge.Ranges.Add(range);
        }

    }
}



