using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using C1.Android.Gauge;
using Android.Graphics;

namespace C1Gauge101
{
    [Activity(Label = "@string/automatic_scaling", MainLauncher = false, Icon = "@drawable/gauge_scaling")]
    public class AutomaticScalingActivity : Activity
    {
        private C1RadialGauge mRadialGauge;
        private TextView mStartText;
        private TextView mSweepText;
        private Random myRandom = new Random();
        private System.Timers.Timer timer = new System.Timers.Timer(3000);
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_automatic_scaling);
            // initialize required widgets
            mStartText = (TextView)FindViewById(Resource.Id.startAngleText);
            mSweepText = (TextView)FindViewById(Resource.Id.sweepAngleText);
            mRadialGauge = (C1RadialGauge)FindViewById(Resource.Id.radialGauge1);

            // setting default values
            mStartText.Text=mRadialGauge.StartAngle.ToString();
            mSweepText.Text=mRadialGauge.SweepAngle.ToString();
            mRadialGauge.Value=60;
            mRadialGauge.Max=200;
            mRadialGauge.ShowText = GaugeShowText.All;
            mRadialGauge.Step=1;
            mRadialGauge.Animate();
            mRadialGauge.AutoScale = true;
           
            // setting timer for auto scaling
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(elapsedEventHandler);
            //timer.Enabled = true;
            //timer.AutoReset = true;
            //timer.Start();

            Button minusButton = (Button)FindViewById(Resource.Id.buttonStartMinus);
            minusButton.Click += button_Click;
            Button plusButton = (Button)FindViewById(Resource.Id.buttonStartPlus);
            plusButton.Click += button_Click;

            Button minusSweepButton = (Button)FindViewById(Resource.Id.buttonSweepMinus);
            minusSweepButton.Click += button_Click;
            Button plusSweepButton = (Button)FindViewById(Resource.Id.buttonSweepPlus);
            plusSweepButton.Click += button_Click;
        }
        private void elapsedEventHandler(object source, System.Timers.ElapsedEventArgs e)
        {
            int mRandom = myRandom.Next(200);
            Action action = new Action(() => { mRadialGauge.Value = mRandom; });
            RunOnUiThread(action);
        }  
        void button_Click(object sender, System.EventArgs e)
        {
            View v = (View)sender;
            switch (v.Id)
            {
                case Resource.Id.buttonStartMinus:
                    mRadialGauge.StartAngle = mRadialGauge.StartAngle - 45;
                    mStartText.Text = mRadialGauge.StartAngle.ToString();
                    break;
                case Resource.Id.buttonStartPlus:
                    mRadialGauge.StartAngle = mRadialGauge.StartAngle + 45;
                    mStartText.Text = mRadialGauge.StartAngle.ToString();
                    break;
                case Resource.Id.buttonSweepMinus:
                    mRadialGauge.SweepAngle = mRadialGauge.SweepAngle - 45;
                    mSweepText.Text = mRadialGauge.SweepAngle.ToString();
                    break;
                case Resource.Id.buttonSweepPlus:
                    mRadialGauge.SweepAngle = mRadialGauge.SweepAngle + 45;
                    mSweepText.Text = mRadialGauge.SweepAngle.ToString();
                    break;
            }
        }
       
    }
}


