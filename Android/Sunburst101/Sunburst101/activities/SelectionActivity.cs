using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Sunburst101
{
    [Activity(Label = "@string/selection", MainLauncher = false, Icon = "@drawable/Selection")]
    public class SelectionActivity : AppCompatActivity
    {
        private C1Sunburst sunburst;
        private TextView mOffset;
        private Button mButtonMinus;
        private Button mButtonPlus;
        private float mOffsetValue = 0.2f;
        private Spinner mSelectionSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_selection);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.selection);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            // initializing widgets
            sunburst = (C1Sunburst)FindViewById(Resource.Id.sunburst);
            mOffset = (TextView)FindViewById(Resource.Id.offset);
            mButtonMinus = (Button)FindViewById(Resource.Id.buttonMinus);
            mButtonPlus = (Button)FindViewById(Resource.Id.buttonPlus);
            mSelectionSpinner = (Spinner)FindViewById(Resource.Id.selectionSpinner);

            // creating a list of objects 
            sunburst.Binding = "Value";
            sunburst.BindingName = "Year,Quarter,Month";
            sunburst.DataLabel.Position = PieLabelPosition.Center;
            sunburst.DataLabel.Content = "{}{name}";
            sunburst.ItemsSource = new SunburstViewModel().FlatData;

            sunburst.SelectionMode = ChartSelectionModeType.Point;
            sunburst.ShowTooltip = false;
            mOffset.Text = mOffsetValue.ToString();
            sunburst.SelectedItemOffset = mOffsetValue;
            sunburst.SelectionMode = ChartSelectionModeType.Point;

            // initializing adapter to string array
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.selection_spinner_values, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mSelectionSpinner.Adapter = adapter;
            mSelectionSpinner.ItemSelected += mSelectionSpinner_ItemSelected;

            mSelectionSpinner.SetSelection(1);

            Button button = (Button)FindViewById(Resource.Id.buttonMinus);
            button.Click += button_Click;
            button = (Button)FindViewById(Resource.Id.buttonPlus);
            button.Click += button_Click;
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
                    sunburst.SelectedItemOffset = mOffsetValue;
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
                    sunburst.SelectedItemOffset = mOffsetValue;
                    break;
            }
        }

        void mSelectionSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // set the position of selected item
            switch (e.Position)
            {
                case 0:
                    sunburst.SelectedItemPosition = ChartPositionType.None;
                    break;
                case 1:
                    sunburst.SelectedItemPosition = ChartPositionType.Left;
                    break;
                case 2:
                    sunburst.SelectedItemPosition = ChartPositionType.Top;
                    break;
                case 3:
                    sunburst.SelectedItemPosition = ChartPositionType.Right;
                    break;
                case 4:
                    sunburst.SelectedItemPosition = ChartPositionType.Bottom;
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