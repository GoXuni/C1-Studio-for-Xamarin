using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using C1.Android.Gauge;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1Gauge101
{
    [Activity(Label = "@string/automatic_scaling", MainLauncher = false, Icon = "@drawable/gauge_scaling")]
    public class AutomaticScalingActivity : AppCompatActivity
    {
        private C1RadialGauge mRadialGauge;
        private TextView mStartText;
        private TextView mSweepText;
        private Button minusButton;
        private Button plusButton;
        private Button minusSweepButton;
        private Button plusSweepButton;
        private Random myRandom = new Random();
        private System.Timers.Timer timer = new System.Timers.Timer(3000);
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_automatic_scaling);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.automatic_scaling);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

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

            minusButton = (Button)FindViewById(Resource.Id.buttonStartMinus);
            minusButton.Enabled = false;
            minusButton.Click += button_Click;
            plusButton = (Button)FindViewById(Resource.Id.buttonStartPlus);
            plusButton.Click += button_Click;

            minusSweepButton = (Button)FindViewById(Resource.Id.buttonSweepMinus);
            minusSweepButton.Click += button_Click;
            plusSweepButton = (Button)FindViewById(Resource.Id.buttonSweepPlus);
            plusSweepButton.Click += button_Click;
        }
        private void elapsedEventHandler(object source, System.Timers.ElapsedEventArgs e)
        {
            int mRandom = myRandom.Next(200);
            Action action = new Action(() => { mRadialGauge.Value = mRandom; });
            RunOnUiThread(action);
        }  

        private void SetStartAngleButtonStatus()
        {
            if (mRadialGauge.StartAngle <= 0)
            {
                minusButton.Enabled = false;
                plusButton.Enabled = true;
            }
            else if (mRadialGauge.StartAngle > 0 && mRadialGauge.StartAngle <360)
            {
                minusButton.Enabled = true;
                plusButton.Enabled = true;
            }
            else if (mRadialGauge.StartAngle >=360)
            {
                minusButton.Enabled = true;
                plusButton.Enabled = false;
            }
        }

        private void SetSweepAngleButtonStatus()
        {
            if (mRadialGauge.SweepAngle <= 45)
            {
                minusSweepButton.Enabled = false;
                plusSweepButton.Enabled = true;
            }
            else if (mRadialGauge.SweepAngle > 45 && mRadialGauge.SweepAngle < 360)
            {
                minusSweepButton.Enabled = true;
                plusSweepButton.Enabled = true;
            }
            else if (mRadialGauge.SweepAngle >= 360)
            {
                minusSweepButton.Enabled = true;
                plusSweepButton.Enabled = false;
            }
        }

        void button_Click(object sender, System.EventArgs e)
        {
            View v = (View)sender;
            switch (v.Id)
            {
                case Resource.Id.buttonStartMinus:
                    mRadialGauge.StartAngle = mRadialGauge.StartAngle - 45;
                    mStartText.Text = mRadialGauge.StartAngle.ToString();
                    SetStartAngleButtonStatus();
                    break;
                case Resource.Id.buttonStartPlus:
                    mRadialGauge.StartAngle = mRadialGauge.StartAngle + 45;
                    mStartText.Text = mRadialGauge.StartAngle.ToString();
                    SetStartAngleButtonStatus();
                    break;
                case Resource.Id.buttonSweepMinus:
                    mRadialGauge.SweepAngle = mRadialGauge.SweepAngle - 45;
                    mSweepText.Text = mRadialGauge.SweepAngle.ToString();
                    SetSweepAngleButtonStatus();
                    break;
                case Resource.Id.buttonSweepPlus:
                    mRadialGauge.SweepAngle = mRadialGauge.SweepAngle + 45;
                    mSweepText.Text = mRadialGauge.SweepAngle.ToString();
                    SetSweepAngleButtonStatus();
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


