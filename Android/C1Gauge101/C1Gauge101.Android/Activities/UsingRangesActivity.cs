using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using C1.Android.Gauge;
using Android.Graphics;
using Java.Util;
using Android.App;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1Gauge101
{
    [Activity(Label = "@string/using_ranges", MainLauncher = false, Icon = "@drawable/gauge_ranges")]
    public class UsingRangesActivity : AppCompatActivity
    {
        private C1LinearGauge mLinearGauge;
        private Switch mSwitchRange;
        private C1RadialGauge mRadialGauge;
        //private GaugeRangeCollection mRanges = new GaugeRangeCollection();
        private int mVal = 25;
        private int mMin = 0;
        private int mMax = 100;
        private TextView mValueText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_using_ranges);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.using_ranges);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mSwitchRange = (Switch)FindViewById(Resource.Id.switchRange);
            mLinearGauge = (C1LinearGauge)FindViewById(Resource.Id.linearGauge1);
            mRadialGauge = (C1RadialGauge)FindViewById(Resource.Id.radialGauge1);
            mValueText = (TextView)FindViewById(Resource.Id.valueText);

            // setting dafault values
            mValueText.Text = mVal.ToString();

            setRange(0, 40, Color.ParseColor("#22B14C"));
            setRange(40, 80, Color.ParseColor("#FF8080"));
            setRange(80, 100, Color.ParseColor("#EEE04A"));

            //mRadialGauge.Ranges = mRanges;
            //mLinearGauge.Ranges = mRanges;

            mRadialGauge.ShowRanges = false;
            mLinearGauge.ShowRanges = false;

            mLinearGauge.Value = mVal;
            mLinearGauge.Min = mMin;
            mLinearGauge.Max = mMax;
            mLinearGauge.Step = 1;
            mLinearGauge.ShowText = GaugeShowText.None;
            //mLinearGauge.GaugeWidth = .5f;

            mRadialGauge.Value = mVal;
            mRadialGauge.Min = mMin;
            mRadialGauge.Max = mMax;
            mRadialGauge.Step = 1;
            mRadialGauge.ShowText = GaugeShowText.None;
            //mRadialGauge.GaugeWidth = .5f;

            mSwitchRange.CheckedChange += mSwitchRange_CheckedChange;

            Button minusButton = (Button)FindViewById(Resource.Id.buttonMinus);
            minusButton.Click += button_Click;
            Button plusButton = (Button)FindViewById(Resource.Id.buttonPlus);
            plusButton.Click += button_Click;

            mLinearGauge.ValueChanged += OnValueChanged;
            mRadialGauge.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object sender, GaugeValueEventArgs e)
        {
            mLinearGauge.Value = e.Value;
            mRadialGauge.Value = e.Value;
            mValueText.Text = ((double)e.Value).ToString(mLinearGauge.Format);
        }

        void mSwitchRange_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            // setting flag for range display
            if (e.IsChecked)
            {
                mLinearGauge.ShowRanges = true;
                mRadialGauge.ShowRanges = true;
            }
            else
            {
                mLinearGauge.ShowRanges = false;
                mRadialGauge.ShowRanges = false;
            }
        }

        void button_Click(object sender, System.EventArgs e)
        {
            View v = (View)sender;
            switch (v.Id)
            {
                case Resource.Id.buttonMinus:
                    // decrease gauge value
                    mVal -= (mVal > mMin) ? 25 : 0;
                    break;
                case Resource.Id.buttonPlus:
                    // increase gauge value
                    mVal += (mVal < mMax) ? 25 : 0;
                    break;
            }
            mLinearGauge.Value = mVal;
            mRadialGauge.Value = mVal;
            mValueText.Text = mVal.ToString();
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