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
    [Activity(Label = "@string/selection", MainLauncher = false, Icon = "@drawable/pie_selection")]
    public class SelectionActivity : AppCompatActivity
    {
        private FlexPie mFlexPie;
        private TextView mOffset;
        private Button mButtonMinus;
        private Button mButtonPlus;
        private float mOffsetValue = 0.2f;
        private Spinner mSelectionSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flexpie_activity_selection);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.selection);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mFlexPie = (FlexPie)FindViewById(Resource.Id.flexPie);
            mOffset = (TextView)FindViewById(Resource.Id.offset);
            mButtonMinus = (Button)FindViewById(Resource.Id.buttonMinus);
            mButtonPlus = (Button)FindViewById(Resource.Id.buttonPlus);
            mSelectionSpinner = (Spinner)FindViewById(Resource.Id.selectionSpinner);

            // creating a list of fruit objects of type BindObject
            IList<Object> flexpieFruits = new List<Object>();
            flexpieFruits.Add(new BindObject("Oranges", 11));
            flexpieFruits.Add(new BindObject("Apples", 94));
            flexpieFruits.Add(new BindObject("Pears", 93));
            flexpieFruits.Add(new BindObject("Bananas", 2));
            flexpieFruits.Add(new BindObject("Pineapples", 53));

            // set the binding of FlexPie to variables of BindObject
            mFlexPie.BindingName = "Name";
            mFlexPie.Binding = "Value";

            // setting the source of data/items and default values in FlexPie
            mFlexPie.ItemsSource = flexpieFruits;
            mOffset.Text = mOffsetValue.ToString();
            mFlexPie.SelectedItemOffset = mOffsetValue;
            mFlexPie.SelectionMode = ChartSelectionModeType.Point;

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
                    mFlexPie.SelectedItemOffset = mOffsetValue;
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
                    mFlexPie.SelectedItemOffset = mOffsetValue;
                    break;
            }
        }

        void mSelectionSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // set the position of selected item
            switch (e.Position)
            {
                case 0:
                    mFlexPie.SelectedItemPosition = ChartPositionType.None;
                    break;
                case 1:
                    mFlexPie.SelectedItemPosition = ChartPositionType.Left;
                    break;
                case 2:
                    mFlexPie.SelectedItemPosition = ChartPositionType.Top;
                    break;
                case 3:
                    mFlexPie.SelectedItemPosition = ChartPositionType.Right;
                    break;
                case 4:
                    mFlexPie.SelectedItemPosition = ChartPositionType.Bottom;
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