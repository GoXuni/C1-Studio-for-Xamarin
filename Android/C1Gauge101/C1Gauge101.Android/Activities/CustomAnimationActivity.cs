using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using C1.Android.Gauge;
using System.Collections.ObjectModel;
using Android.Graphics;
using Java.Util;

namespace C1Gauge101
{
    [Activity(Label = "@string/custom_animation", MainLauncher = false, Icon = "@drawable/gauge_basic")]
    public class CustomAnimationActivity : Activity
    {
        private static C1RadialGauge mRadialGauge;
        private static C1LinearGauge mLinearGauge;
        //private ObservableCollection<GaugeRange> mRanges = new ObservableCollection<GaugeRange>();
        private System.Random myRandom = new System.Random();
        private System.Timers.Timer timer = new System.Timers.Timer(3000);

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_custom_animation);
            // initializing widgets
            mRadialGauge = (C1RadialGauge)FindViewById(Resource.Id.radialGauge1);
            mLinearGauge = (C1LinearGauge)FindViewById(Resource.Id.linearGauge1);

            // disabling the touch events on the gauges
            mRadialGauge.Enabled = false;
            mLinearGauge.Enabled = false;

            //setting default values
            setRange(0, 40, -65536);
            setRange(40, 80, -256);
            setRange(80, 100, -16711936);

            //mRadialGauge.Ranges = mRanges;
            //mLinearGauge.Ranges = mRanges;

            mRadialGauge.ShowRanges = true;
            mLinearGauge.ShowRanges = true;
            mRadialGauge.IsAnimated = true;
            mLinearGauge.IsAnimated = true;

            mRadialGauge.Value = 60;
            mRadialGauge.Min = 0;
            mRadialGauge.Max = 100;
            mRadialGauge.ShowText = GaugeShowText.All;
            //mRadialGauge.ControlWidth = .5f;

            mLinearGauge.Value = 60;
            mLinearGauge.Min = 0;
            mLinearGauge.Max = 100;
            mLinearGauge.ShowText = GaugeShowText.None;
            //mLinearGauge.GaugeWidth = .5f;

            mRadialGauge.Animate();
            mLinearGauge.Animate();

            // setting timer for auto scaling
            timer.Elapsed += new System.Timers.ElapsedEventHandler(elapsedEventHandler);
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
        }

        private void elapsedEventHandler(object source, System.Timers.ElapsedEventArgs e)
        {
            int mRandom = myRandom.Next(100);
            Action action = new Action(() =>
            {
                mRadialGauge.Value = mRandom;
                mLinearGauge.Value = mRandom;
            });
            RunOnUiThread(action);
        }

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


