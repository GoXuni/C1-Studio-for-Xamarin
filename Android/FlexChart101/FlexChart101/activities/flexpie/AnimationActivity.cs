using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using C1.Android.Chart;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using C1.Android.Core;
using C1.DataCollection;

namespace FlexChart101.Pie
{
    [Activity(Label = "@string/animationOptions", MainLauncher = false, Icon = "@drawable/pie_selection")]
    public class AnimationActivity : AppCompatActivity
    {
        private FlexPie mFlexPie;
        private TextView mOffset;
        private Button mButtonMinus;
        private Button mButtonPlus;
        private float mOffsetValue = 0.0f;
        private Spinner mSelectionSpinner;

        C1DataCollection<BindObject> data;
        const string TITLE = "Mobile/Tablet Browser Market Share";

        double[] safari = new double[] { 41.54, 48.35, 57.48, 61.67 };
        double[] chrome = new double[] { 28.51, 17.12, 4.79, 0.76 };
        double[] android_browser = new double[] { 15.8, 21.54, 26.54, 20.61 };
        double[] opera_mini = new double[] { 7.62, 6.65, 8.7, 11.91 };
        double[] internet_explorer = new double[] { 2.36, 5.2, 1.74, 0.81 };
        double[] other = new double[] { 1.68, 2.1, 2.45, 1.83 };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flexpie_activity_animation);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.animationOptions);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mFlexPie = (FlexPie)FindViewById(Resource.Id.flexPie);
            mOffset = (TextView)FindViewById(Resource.Id.offset);
            mButtonMinus = (Button)FindViewById(Resource.Id.buttonMinus);
            mButtonPlus = (Button)FindViewById(Resource.Id.buttonPlus);
            mSelectionSpinner = (Spinner)FindViewById(Resource.Id.selectionSpinner);

            mFlexPie.Header = TITLE + " 2015";
            // prepare data source
            List<BindObject> list = new List<BindObject>();
            list.Add(new BindObject("Safari", safari[0] ));
            list.Add(new BindObject("Chrome", chrome[0] ));
            list.Add(new BindObject("Android", android_browser[0] ));
            list.Add(new BindObject("Opera", opera_mini[0] ));
            list.Add(new BindObject("IE", internet_explorer[0] ));
            list.Add(new BindObject("Other", other[0] ));
            data = new C1DataCollection<BindObject>(list);
            
            // set the binding of FlexPie to variables of BindObject
            mFlexPie.BindingName = "Name";
            mFlexPie.Binding = "DoubleValue";

            // setting default values in FlexPie
            mFlexPie.ItemsSource = data;
            mFlexPie.SelectedItemOffset = 0.1;
            mFlexPie.SelectionMode = ChartSelectionModeType.Point;
            mFlexPie.SelectedItemPosition = ChartPositionType.Top;
            mFlexPie.ToolTip = null;

            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1000 * 10000);
            loadAnimation.Easing = new Android.Views.Animations.LinearInterpolator();
            mFlexPie.LoadAnimation = loadAnimation;
            C1Animation updateAnimation = new C1Animation();
            updateAnimation.Duration = new TimeSpan(1000 * 10000);
            updateAnimation.Easing = C1Easing.Linear;
            mFlexPie.UpdateAnimation = updateAnimation;

            // initializing adapter to string array
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.animationModeSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mSelectionSpinner.Adapter = adapter;
            mSelectionSpinner.ItemSelected += mSelectionSpinner_ItemSelected;
            
            mSelectionSpinner.SetSelection(1);
          
            Button buttonMinus = (Button)FindViewById(Resource.Id.buttonMinus);
            Button buttonPlus = (Button)FindViewById(Resource.Id.buttonPlus);
            buttonMinus.Click += button_Click;
            buttonPlus.Click += button_Click;

            Button button2015 = (Button)FindViewById(Resource.Id.button2015);
            Button button2014 = (Button)FindViewById(Resource.Id.button2014);
            Button button2013 = (Button)FindViewById(Resource.Id.button2013);
            Button button2012 = (Button)FindViewById(Resource.Id.button2012);
            button2015.Click += Button2015_Click;
            button2014.Click += Button2014_Click;
            button2013.Click += Button2013_Click;
            button2012.Click += Button2012_Click;
        }

        private async void Button2015_Click(object sender, EventArgs e)
        {
            mFlexPie.BeginUpdate();
            mFlexPie.Header = TITLE + " 2015";
            await data.ReplaceAsync(0, new BindObject("Safari", safari[0]));
            await data.ReplaceAsync(1, new BindObject("Chrome", chrome[0]));
            await data.ReplaceAsync(2, new BindObject("Android", android_browser[0]));
            await data.ReplaceAsync(3, new BindObject("Opera", opera_mini[0]));
            await data.ReplaceAsync(4, new BindObject("IE", internet_explorer[0]));
            await data.ReplaceAsync(5, new BindObject("Other", other[0]));
            mFlexPie.EndUpdate();
        }
        private async void Button2014_Click(object sender, EventArgs e)
        {
            mFlexPie.BeginUpdate();
            mFlexPie.Header = TITLE + " 2014";
            await data.ReplaceAsync(0, new BindObject("Safari", safari[1]));
            await data.ReplaceAsync(1, new BindObject("Chrome", chrome[1]));
            await data.ReplaceAsync(2, new BindObject("Android", android_browser[1]));
            await data.ReplaceAsync(3, new BindObject("Opera", opera_mini[1]));
            await data.ReplaceAsync(4, new BindObject("IE", internet_explorer[1]));
            await data.ReplaceAsync(5, new BindObject("Other", other[1]));
            mFlexPie.EndUpdate();
        }
        private async void Button2013_Click(object sender, EventArgs e)
        {
            mFlexPie.BeginUpdate();
            mFlexPie.Header = TITLE + " 2013";
            await data.ReplaceAsync(0, new BindObject("Safari", safari[2]));
            await data.ReplaceAsync(1, new BindObject("Chrome", chrome[2]));
            await data.ReplaceAsync(2, new BindObject("Android", android_browser[2]));
            await data.ReplaceAsync(3, new BindObject("Opera", opera_mini[2]));
            await data.ReplaceAsync(4, new BindObject("IE", internet_explorer[2]));
            await data.ReplaceAsync(5, new BindObject("Other", other[2]));
            mFlexPie.EndUpdate();
        }
        private async void Button2012_Click(object sender, EventArgs e)
        {
            mFlexPie.BeginUpdate();
            mFlexPie.Header = TITLE + " 2012";
            await data.ReplaceAsync(0, new BindObject("Safari", safari[3]));
            await data.ReplaceAsync(1, new BindObject("Chrome", chrome[3]));
            await data.ReplaceAsync(2, new BindObject("Android", android_browser[3]));
            await data.ReplaceAsync(3, new BindObject("Opera", opera_mini[3]));
            await data.ReplaceAsync(4, new BindObject("IE", internet_explorer[3]));
            await data.ReplaceAsync(5, new BindObject("Other", other[3]));
            mFlexPie.EndUpdate();
        }

        void button_Click(object sender, System.EventArgs e)
        {
            View v = (View)sender;
            switch (v.Id)
            {
                case Resource.Id.buttonMinus:
                    // decrease offset value
                    mOffsetValue -= (float)(mOffsetValue > 0 ? 0.1 : 0);
                    mOffsetValue = ((int)(mOffsetValue * 10)) / 10f;

                    if (mOffsetValue == 0f)
                        mButtonMinus.Enabled = false;
                    else if (!mButtonPlus.Enabled)
                        mButtonPlus.Enabled = true;

                    mOffset.Text = mOffsetValue.ToString();
                    mFlexPie.InnerRadius = mOffsetValue;
                    break;

                case Resource.Id.buttonPlus:
                    // increase offset value
                    mOffsetValue += (float)(mOffsetValue < 1 ? 0.1 : 0);
                    mOffsetValue = ((int)(mOffsetValue * 10)) / 10f;

                    if (mOffsetValue == 1f)
                        mButtonPlus.Enabled = false;
                    else if (!mButtonMinus.Enabled)
                        mButtonMinus.Enabled = true;

                    mOffset.Text = mOffsetValue.ToString();
                    mFlexPie.InnerRadius = mOffsetValue;
                    break;
            }
        }

        void mSelectionSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // set the position of selected item
            switch (e.Position)
            {
                case 0:
                    mFlexPie.AnimationMode = AnimationMode.None;
                    break;
                case 1:
                    mFlexPie.AnimationMode = AnimationMode.Point;
                    break;
                case 2:
                    mFlexPie.AnimationMode = AnimationMode.Series;
                    break;
                case 3:
                    mFlexPie.AnimationMode = AnimationMode.All;
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