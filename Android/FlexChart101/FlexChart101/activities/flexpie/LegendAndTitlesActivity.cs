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
    [Activity(Label = "@string/legend_and_titles", MainLauncher = false, Icon = "@drawable/pie_title")]

    public class LegendAndTitlesActivity : AppCompatActivity
    {
        private FlexPie mFlexPie;
        private EditText mHeaderValue;
        private EditText mFooterValue;
        private Spinner mLegendSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flexpie_activity_legend_and_titles);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.legend_and_titles);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mFlexPie = (FlexPie)FindViewById(Resource.Id.flexPie);
            mHeaderValue = (EditText)FindViewById(Resource.Id.headerValue);
            mFooterValue = (EditText)FindViewById(Resource.Id.footerValue);
            mLegendSpinner = (Spinner)FindViewById(Resource.Id.legendSpinner);

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
            mFlexPie.LegendPosition = ChartPositionType.Auto;

            // setting the source of data/items and default values in FlexPie
            mFlexPie.ItemsSource = flexpieFruits;
            mFlexPie.Header = mHeaderValue.Text;
            mFlexPie.Footer = mFooterValue.Text;

            // initializing adapter to string array
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.legend_spinner_values, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mLegendSpinner.Adapter = adapter;
            mLegendSpinner.ItemSelected += mLegendSpinner_ItemSelected;
            mHeaderValue.TextChanged += mHeaderValue_TextChanged;
            mFooterValue.TextChanged += mFooterValue_TextChanged;

        }

        void mFooterValue_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            // setting footer value as editText value
            mFlexPie.Footer = mFooterValue.Text;
        }

        void mHeaderValue_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            // setting header value as editText value
            mFlexPie.Header = mHeaderValue.Text;
        }

        public void mLegendSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // setting position of legend based on user selection
            switch (e.Position)
            {
                case 0:
                    mFlexPie.LegendPosition = ChartPositionType.Auto;
                    break;
                case 1:
                    mFlexPie.LegendPosition = ChartPositionType.Left;
                    break;
                case 2:
                    mFlexPie.LegendPosition = ChartPositionType.Top;
                    break;
                case 3:
                    mFlexPie.LegendPosition = ChartPositionType.Right;
                    break;
                case 4:
                    mFlexPie.LegendPosition = ChartPositionType.Bottom;
                    break;
                case 5:
                    mFlexPie.LegendPosition = ChartPositionType.None;
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