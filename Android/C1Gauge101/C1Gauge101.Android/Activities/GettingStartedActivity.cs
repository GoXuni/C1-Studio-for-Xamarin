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
    [Activity(Label = "@string/getting_started", MainLauncher = false, Icon = "@drawable/gauge_basic")]
    public class GettingStartedActivity : Activity
    {
        private C1LinearGauge mLinearGauge;
        private C1RadialGauge mRadialGauge;
        private C1BulletGraph mBulletGraph;
        private TextView mValueText;
        private int mValue = 25;
        private int mMin = 0;
        private int mMax = 100;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_getting_started);

            // initializing widgets
            mRadialGauge = (C1RadialGauge)FindViewById(Resource.Id.radialGauge1);
            mLinearGauge = (C1LinearGauge)FindViewById(Resource.Id.linearGauge1);
            mBulletGraph = (C1BulletGraph)FindViewById(Resource.Id.bulletGraph1);
            mValueText = (TextView)FindViewById(Resource.Id.valueText);

            // setting dafault values
            mValueText.Text = mValue.ToString();
            mBulletGraph.Enabled = true;
            mBulletGraph.Value = mValue;
            mBulletGraph.Bad = 45;
            mBulletGraph.Good = 80;
            mBulletGraph.Min = mMin;
            mBulletGraph.Max = mMax;
            mBulletGraph.Target = 90;
            mBulletGraph.ShowText = GaugeShowText.All;
            mBulletGraph.Step = 1;
            mBulletGraph.IsReadOnly = false;
            mBulletGraph.IsAnimated = true;

            mLinearGauge.Enabled = true;
            mLinearGauge.Value = mValue;
            mLinearGauge.Min = mMin;
            mLinearGauge.Max = mMax;
            mLinearGauge.Step = 1;
            mLinearGauge.ShowText = GaugeShowText.All;
            mLinearGauge.IsReadOnly = false;
            mLinearGauge.IsAnimated = true;

            mRadialGauge.Enabled = true;
            mRadialGauge.Value = mValue;
            mRadialGauge.Min = mMin;
            mRadialGauge.Max = mMax;
            mRadialGauge.Step = 1;
            mRadialGauge.ShowText = GaugeShowText.All;
            mRadialGauge.IsReadOnly = false;
            mRadialGauge.IsAnimated = true;

            Button minusButton = (Button)FindViewById(Resource.Id.buttonValueMinus);
            minusButton.Click += button_Click;
            Button plusButton = (Button)FindViewById(Resource.Id.buttonValuePlus);
            plusButton.Click += button_Click;

            mLinearGauge.ValueChanged += OnValueChanged;
            mRadialGauge.ValueChanged += OnValueChanged;
            mBulletGraph.ValueChanged += OnValueChanged;
        }

        void button_Click(object sender, System.EventArgs e)
        {
            View v = (View)sender;
            switch (v.Id)
            {
                case Resource.Id.buttonValueMinus:
                    // decrease gauge value
                    mValue -= (mValue > mMin) ? 25 : 0;
                    break;
                case Resource.Id.buttonValuePlus:
                    // increase gauge value
                    mValue += (mValue < mMax) ? 25 : 0;
                    break;
            }
            mLinearGauge.Value = mValue;
            mRadialGauge.Value = mValue;
            mBulletGraph.Value = mValue;
            mValueText.Text = mValue.ToString();
        }

        public void OnValueChanged(object sender, GaugeValueEventArgs e)
        {
            mLinearGauge.Value = e.Value;
            mRadialGauge.Value = e.Value;
            mBulletGraph.Value = e.Value;
        }

    }
}