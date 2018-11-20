using System;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Graphics;
using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace FlexChart101.Pie
{
    [Activity(Label = "@string/data_labels", MainLauncher = false, Icon = "@drawable/pie_selection")]
    public class DataLabelsActivity : AppCompatActivity
    {
        private FlexPie mFlexPie;
        private Spinner mDataLabelSpinner;
        private IList<Object> mFlexdonutFruits;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flexpie_activity_data_labels);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.dataLabels);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mFlexPie = (FlexPie)FindViewById(Resource.Id.flexPie);
            mDataLabelSpinner = (Spinner)FindViewById(Resource.Id.dataLabelSpinner);

            // creating a list of fruit objects of type BindObject
            mFlexdonutFruits = new List<Object>();
            mFlexdonutFruits.Add(new BindObject("Oranges", 11));
            mFlexdonutFruits.Add(new BindObject("Apples", 94));
            mFlexdonutFruits.Add(new BindObject("Pears", 93));
            mFlexdonutFruits.Add(new BindObject("Bananas", 2));
            mFlexdonutFruits.Add(new BindObject("Pineapples", 53));

            // set the binding of FlexPie to variables of BindObject
            mFlexPie.BindingName = "Name";
            mFlexPie.Binding = "Value";

            // setting the source of data/items in FlexPie
            mFlexPie.ItemsSource = mFlexdonutFruits;
                    
            mFlexPie.DataLabel.Content = "{y}";
            mFlexPie.DataLabel.Border = true;
            mFlexPie.DataLabel.BorderStyle = new ChartStyle() { Stroke = Color.Green, StrokeThickness = 2, Fill = Color.Transparent };

            //MarginF mPlotMargin = new MarginF(30f, 30f, 30f, 30f);
            //mFlexPie.PlotMargin = mPlotMargin;

            // create custom adapter for spinner and initialize with string array
            ArrayAdapter adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.pieDataLabelPositionSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mDataLabelSpinner.Adapter = adapter1;

            mDataLabelSpinner.ItemSelected += mDataLabelSpinner_ItemSelected;

        }

        void mDataLabelSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // set chart label position
            switch (e.Position)
            {
                case 0:
                    mFlexPie.DataLabel.Position = PieLabelPosition.None;
                    break;
                case 1:
                    mFlexPie.DataLabel.Position = PieLabelPosition.Center;
                    break;
                case 2:
                    mFlexPie.DataLabel.Position = PieLabelPosition.Inside;
                    break;
                case 3:
                    mFlexPie.DataLabel.Position = PieLabelPosition.Outside;
                    break;
                case 4:
                    mFlexPie.DataLabel.Position = PieLabelPosition.Radial;
                    break;
                case 5:
                    mFlexPie.DataLabel.Position = PieLabelPosition.Circular;
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