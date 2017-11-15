using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101.Pie
{
    [Activity(Label = "@string/basic_features", MainLauncher = false, Icon = "@drawable/pie_doughnut")]
    public class BasicFeaturesActivity : AppCompatActivity
    {
        private FlexPie mflexPie;
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
            SetContentView(Resource.Layout.flexpie_activity_basic_features);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.basic_features);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mflexPie = (FlexPie)FindViewById(Resource.Id.donutPie);
            mRadius = (TextView)FindViewById(Resource.Id.radius);
            mReversedSwitch = (Switch)FindViewById(Resource.Id.reversedSwitch);
            mOffsetSeekbar = (SeekBar)FindViewById(Resource.Id.offsetSeekBar);
            mStartAngleSeekbar = (SeekBar)FindViewById(Resource.Id.startAngleSeekBar);
            mButtonMinus = (Button)FindViewById(Resource.Id.buttonMinus);
            mButtonPlus = (Button)FindViewById(Resource.Id.buttonPlus);

            // creating a list of fruit objects of type BindObject
            IList<Object> mFlexdonutFruits = new List<Object>();
            mFlexdonutFruits.Add(new BindObject("Oranges", 11));
            mFlexdonutFruits.Add(new BindObject("Apples", 94));
            mFlexdonutFruits.Add(new BindObject("Pears", 93));
            mFlexdonutFruits.Add(new BindObject("Bananas", 2));
            mFlexdonutFruits.Add(new BindObject("Pineapples", 53));

            // set the binding of FlexPie to variables of BindObject
            mflexPie.BindingName = "Name";
            mflexPie.Binding = "Value";

            // setting the source of data/items in FlexPie
            mflexPie.ItemsSource = mFlexdonutFruits;

            // setting default values
            mRadius.Text = mInnerRadius.ToString();
            mflexPie.InnerRadius = mInnerRadius;

            mReversedSwitch.CheckedChange += mReversedSwitch_CheckedChange;

            mOffsetSeekbar.ProgressChanged += mOffsetSeekbar_ProgressChanged;
            mStartAngleSeekbar.ProgressChanged += mStartAngleSeekbar_ProgressChanged;

            Button button = (Button)FindViewById(Resource.Id.buttonMinus);
            button.Click += button_Click;
            button = (Button)FindViewById(Resource.Id.buttonPlus);
            button.Click += button_Click;
        }

        void mOffsetSeekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            // calculating and setting offset from progress of seekbar
            float progress = e.Progress / 100f;
            mflexPie.Offset = progress;
        }

        void mStartAngleSeekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            // calculating and setting start angle from progress of seekbar
            float progress = e.Progress * 3.6f;
            mflexPie.StartAngle = progress;
        }

        void mOffsetSeekbar_ScrollChange(object sender, View.ScrollChangeEventArgs e)
        {
            // calculating and setting offset from progress of seekbar
            float progress = e.ScrollX / 100f;
            mflexPie.Offset = progress;
        }
        void mReversedSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            mflexPie.Reversed = e.IsChecked;
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
                    mflexPie.InnerRadius = mInnerRadius;
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
                    mflexPie.InnerRadius = mInnerRadius;
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