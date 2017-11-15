using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using C1.Android.Chart;
using Android.Graphics;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Sunburst101
{
    [Activity(Label = "@string/basic_features", MainLauncher = false, Icon = "@drawable/BasicFeatures")]
    public class BasicFeaturesActivity : AppCompatActivity
    {
        private C1Sunburst sunburst;
        private float mInnerRadius = 0.3f;
        private TextView mRadius;
        private Switch mReversedSwitch;
        private SeekBar mOffsetSeekbar;
        private SeekBar mStartAngleSeekbar;
        private Button mButtonMinus;
        private Button mButtonPlus;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_basic_features);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.basic_features);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            sunburst = (C1Sunburst)FindViewById(Resource.Id.sunburst);
            mRadius = (TextView)FindViewById(Resource.Id.radius);
            mReversedSwitch = (Switch)FindViewById(Resource.Id.reversedSwitch);
            mOffsetSeekbar = (SeekBar)FindViewById(Resource.Id.offsetSeekBar);
            mStartAngleSeekbar = (SeekBar)FindViewById(Resource.Id.startAngleSeekBar);
            mButtonMinus = (Button)FindViewById(Resource.Id.buttonMinus);
            mButtonPlus = (Button)FindViewById(Resource.Id.buttonPlus);

            sunburst.Binding = "Value";
            sunburst.BindingName = "Year,Quarter,Month";
            sunburst.ChildItemsPath = "Items";
            sunburst.ToolTipContent = "{}{name}\n{y}";
            sunburst.DataLabel.Position = PieLabelPosition.Center;
            sunburst.DataLabel.Content = "{}{name}";
            sunburst.ItemsSource = new SunburstViewModel().HierarchicalData;

            // setting default values
            mRadius.Text = mInnerRadius.ToString();
            sunburst.InnerRadius = mInnerRadius;

            mReversedSwitch.CheckedChange += mReversedSwitch_CheckedChange;

            mOffsetSeekbar.ProgressChanged += mOffsetSeekbar_ProgressChanged;
            mStartAngleSeekbar.ProgressChanged += mStartAngleSeekbar_ProgressChanged;

            Button button = (Button)FindViewById(Resource.Id.buttonMinus);
            button.Click += button_Click;
            button = (Button)FindViewById(Resource.Id.buttonPlus);
            button.Click += button_Click;

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
        void mOffsetSeekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            // calculating and setting offset from progress of seekbar
            float progress = e.Progress / 100f;
            sunburst.Offset = progress;
        }

        void mStartAngleSeekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            // calculating and setting start angle from progress of seekbar
            float progress = e.Progress * 3.6f;
            sunburst.StartAngle = progress;
        }

        void mOffsetSeekbar_ScrollChange(object sender, View.ScrollChangeEventArgs e)
        {
            // calculating and setting offset from progress of seekbar
            float progress = e.ScrollX / 100f;
            sunburst.Offset = progress;
        }
        void mReversedSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            sunburst.Reversed = e.IsChecked;
        }

        void button_Click(object sender, System.EventArgs e)
        {
            View v = (View)sender;
            switch (v.Id)
            {
                case Resource.Id.buttonMinus:
                    // decrease inner radius
                    mInnerRadius -= (float)(mInnerRadius > 0 ? 0.1 : 0);
                    mInnerRadius = ((int)(mInnerRadius * 10)) / 10f;

                    // enable button only for valid radius
                    if (mInnerRadius == 0f)
                        mButtonMinus.Enabled = false;
                    else if (!mButtonPlus.Enabled)
                        mButtonPlus.Enabled = true;

                    mRadius.Text = mInnerRadius.ToString();
                    sunburst.InnerRadius = mInnerRadius;
                    break;

                case Resource.Id.buttonPlus:
                    // increase inner radius
                    mInnerRadius += (float)(mInnerRadius < 1 ? 0.1 : 0);
                    mInnerRadius = ((int)(mInnerRadius * 10)) / 10f;

                    // enable button only for valid radius
                    if (mInnerRadius == 1f)
                        mButtonPlus.Enabled = false;
                    else if (!mButtonMinus.Enabled)
                        mButtonMinus.Enabled = true;

                    mRadius.Text = mInnerRadius.ToString();
                    sunburst.InnerRadius = mInnerRadius;
                    break;
            }
        }
    }
}